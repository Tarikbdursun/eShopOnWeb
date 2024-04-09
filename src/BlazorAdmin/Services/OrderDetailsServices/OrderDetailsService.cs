using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models.OrderDetailsModels;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Services;
using Microsoft.eShopWeb.Infrastructure.Data;

namespace BlazorAdmin.Services.OrderDetailsServices;

public class OrderDetailsService : IOrderDetailsService
{
    private readonly HttpService _httpService;
    private readonly IOrderService _orderService;

    public OrderDetailsService(HttpService httpService, IOrderService orderService)
    {
        _httpService = httpService;
        //var dbContext = new CatalogContext(new Microsoft.EntityFrameworkCore.DbContextOptions<CatalogContext>());
        //_orderService=new OrderService
        //    (
        //        //new EfRepository<Basket>(dbContext),
        //        //new EfRepository<CatalogItem>(dbContext),
        //        new EfRepository<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order>(dbContext)
        //       // new UriComposer(new Microsoft.eShopWeb.CatalogSettings())
        //    );
        _orderService = orderService;
    }

    public async Task<List<Order>> List()
    {
        //List<Order> list;
        //var task = await _httpService.HttpGet<List<Order>>("orders");
        //if (task.Count == 0)
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

        //var list = new List<Order>
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

        //return list;

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
        var listOrderTask = await _orderService.List();
        var order = listOrderTask.FirstOrDefault(x => x.Id == orderId);
        var itemOrders = order.OrderItems;
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
        //await _httpService.HttpPut<object>($"set-order-status/{orderId}?status={status}", null);
        await _orderService.SetOrderStatus(orderId, status);
    }
}
