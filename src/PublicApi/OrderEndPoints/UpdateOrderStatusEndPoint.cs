using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;
using MinimalApi.Endpoint;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.eShopWeb.PublicApi.OrderEndPoints.UpdateOrderStatusEndPoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class UpdateOrderStatusEndPoint : IEndpoint<IResult, UpdateOrderStatusRequest, IRepository<Order>>
{
    private readonly IUriComposer _uriComposer;

    public UpdateOrderStatusEndPoint(IUriComposer uriComposer)
    {
        _uriComposer = uriComposer;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPut("api/orders/{orderId}?status={status}",
            [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] async
            (int orderId, short status, UpdateOrderStatusRequest request, IRepository<Order> orderRepository) =>
            {
                return await HandleAsync(request, orderRepository);
            })
            .Produces<UpdateOrderStatusResponse>()
            .WithTags("OrderEndPoints");
    }

    public async Task<IResult> HandleAsync(UpdateOrderStatusRequest request, IRepository<Order> orderRepository)
    {
        var response = new UpdateOrderStatusResponse(request.CorrelationId());

        var existingItem = await orderRepository.GetByIdAsync(request.Id);
        if (existingItem == null)
        {
            return Results.NotFound();
        }
        existingItem.Status = (OrderStatus)request.Status;

        await orderRepository.UpdateAsync(existingItem);

        var dto = new OrderDto
        {
            OrderId = existingItem.Id,
            BuyerId = existingItem.BuyerId,
            Items = existingItem.OrderItems.ToList(),
            OrderDate = existingItem.OrderDate,
            Status = (short)existingItem.Status,
            TotalPrice = existingItem.Total(),
            Address =
                    $"{existingItem.ShipToAddress.Street} " +
                    $"{existingItem.ShipToAddress.City} " +
                    $"{existingItem.ShipToAddress.State} " +
                    $"{existingItem.ShipToAddress.Country} " +
                    $"{existingItem.ShipToAddress.ZipCode}",
        };

        response.OrderDto = dto;
        return Results.Ok(response);
    }

    public class UpdateOrderStatusRequest : BaseRequest
    {
        [Range(1, 10000)]
        public int Id { get; set; }
        [Range(0, 1)]
        public short Status { get; set; }
    }

    public class UpdateOrderStatusResponse : BaseResponse
    {
        public UpdateOrderStatusResponse(Guid correlationId) : base(correlationId)
        {
            
        }

        public UpdateOrderStatusResponse()
        {
        }

        public OrderDto OrderDto { get; set; }
    }
}
