using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models.OrderDetailsModels;

namespace BlazorAdmin.Services.OrderDetailsServices;

public class OrderDetailsService : IOrderDetailsService
{
    //private readonly IOrderService _orderService;
    private readonly HttpService _httpService;

    public OrderDetailsService(HttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<List<Order>> List()
    {
        return await _httpService.HttpGet<List<Order>>("orders");
    }

    public async Task<List<OrderDetails>> ListDetails(int orderId)
    {
        return await _httpService.HttpGet<List<OrderDetails>>($"orders/{orderId}");
    }

    public async Task SetOrderStatus(int orderId, short status)
    {
        await _httpService.HttpPut<object>($"set-order-status/{orderId}?status={status}", null);
    }
}
