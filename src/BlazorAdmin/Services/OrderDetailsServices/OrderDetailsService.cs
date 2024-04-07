using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using BlazorShared.Models.OrderDetailsModels;
using Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Services;
using Microsoft.Extensions.Logging;

namespace BlazorAdmin.Services.OrderDetailsServices;

public class OrderDetailsService : IOrderDetailsService
{
    private readonly IRepository<Order> _orderRepository; 

    public OrderDetailsService(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<OrderDetails>> List()
    {
        var orders = (await _orderRepository.ListAsync()).OrderBy(x => x.Id);

        List<OrderDetails> orderDetails = new List<OrderDetails>();
        foreach (var order in orders)
        {
            orderDetails.Add(new OrderDetails
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

        return orderDetails;
    }

    public async Task<List<OrderDetailsModel>> ListDetails(int orderId) 
    {
        var itemOrders = (await _orderRepository.GetByIdAsync(orderId)).OrderItems;
        

        List<OrderDetailsModel> orderDetails = new List<OrderDetailsModel>();
        foreach (var item in itemOrders)
        {
            orderDetails.Add(new OrderDetailsModel
            {
                CatalogItemOrdered=item.ItemOrdered,
                UnitPrice=item.UnitPrice,
                Units=item.Units,
            });
        }

        return orderDetails.ToList();
    }
}
