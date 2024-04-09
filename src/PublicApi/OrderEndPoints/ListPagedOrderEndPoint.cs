using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class ListPagedOrderEndPoint : IEndpoint<IResult, IRepository<Order>>
{
    private readonly IMapper _mapper;

    public ListPagedOrderEndPoint(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
           app.MapGet("api/orders",
            async (IRepository<Order> orderRepository) =>
            {
                return await HandleAsync(orderRepository);
            })
            .Produces<ListPagedOrderResponse>()
            .WithTags("OrderEndPoints");
    }

    public async Task<IResult> HandleAsync(IRepository<Order> orderRepository)
    {
        var response = new ListPagedOrderResponse();

        var items = await orderRepository.ListAsync();

        

        response.Orders.AddRange(items.Select(_mapper.Map<OrderDto>));

        return Results.Ok(response);
    }
}
