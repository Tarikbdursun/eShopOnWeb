using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models.OrderDetailsModels;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace BlazorAdmin.Services.OrderDetailsServices;

public class OrderDetailsService : IOrderDetailsService
{
    private readonly HttpService _httpService;
    private readonly IOrderService _orderService;

    public OrderDetailsService(HttpService httpService, IOrderService orderService)
    {
        _httpService = httpService;
        _orderService = orderService;
    }

    public async Task<List<Order>> List()
    {
        //List<Order> list;
        //var task=await _httpService.HttpGet<List<Order>>("orders");
        //if (task.Count==0) 
        //{
        //    list = new List<Order>
        //    {
        //        new Order
        //        {
        //            Address="Ankara Yenimahalle",
        //            BuyerId="1",
        //            Items=new List<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.OrderItem>(),
        //            OrderDate=DateTime.Today,
        //            OrderId=1,
        //            Status=0,
        //            TotalPrice=90
        //        }
        //    };

        //    return list;
        //}
        //return task;

        var orders = await _orderService.List();
        List<Order> orderModels = new();

        foreach (var order in orders)
        {
            orderModels.Add(new Order

            {
                OrderId = order.Id,
                BuyerId = order.BuyerId,
                Address =
                    $"{order.ShipToAddress.Street} " +
                    $"{order.ShipToAddress.City} " +
                    $"{order.ShipToAddress.State} " +
                    $"{order.ShipToAddress.Country} " +
                    $"{order.ShipToAddress.ZipCode}",
                OrderDate = order.OrderDate,
                Items = order.OrderItems.ToList(),
                Status = (short)order.Status,
                TotalPrice = order.Total()
            });
        }

        return orderModels;
    }

    public async Task<List<OrderDetails>> ListDetails(int orderId)
    {
        var listOrderTask= await _httpService.HttpGet<List<Order>>("orders");
        var order=listOrderTask.FirstOrDefault(x => x.OrderId == orderId);
        var itemOrders = order.Items;
        var orderDetails = new List<OrderDetails>();
        foreach (var item in itemOrders) 
        {
            orderDetails.Add(new OrderDetails
            {
                CatalogItemOrdered = item.ItemOrdered,
                UnitPrice = item.UnitPrice,
                Units = item.Units,
            });
        }

        return orderDetails;
    }

    public async Task SetOrderStatus(int orderId, short status)
    {
        await _httpService.HttpPut<object>($"set-order-status/{orderId}?status={status}", null);
    }
}
