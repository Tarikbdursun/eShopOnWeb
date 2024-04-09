using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;
using Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints;
using MinimalApi.Endpoint;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class GetOrderDetailEndPoint : IEndpoint<IResult, IRepository<Order>>
{
    private readonly IMapper _mapper;

    public GetOrderDetailEndPoint(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders/{orderId}",
         async (int orderId, IRepository<Order> orderRepository) =>
         {
             return await HandleAsync(orderRepository);
         })
         .Produces<GetOrderDetailsResponse>()
         .WithTags("OrderEndPoints");
    }

    public async Task<IResult> HandleAsync(IRepository<Order> orderRepository)
    {
        var response = new GetOrderDetailsResponse();

        var items = await orderRepository.ListAsync();

        response.OrderDetails.AddRange(items.Select(_mapper.Map<OrderDetailsDto>));

        return Results.Ok(response);
    }
}
