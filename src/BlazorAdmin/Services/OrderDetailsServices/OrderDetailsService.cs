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
    private readonly HttpService _httpService;
    private readonly IRepository<Order> _orderRepository; 

    public OrderDetailsService(
        HttpService httpService,
        IRepository<Order> orderRepository)
    {
        _httpService = httpService;
        _orderRepository = orderRepository;
    }




    public async Task<OrderDetails> GetByOrderIdAsync(int orderId) 
    {
        var getOrderTask= _orderRepository.GetByIdAsync(orderId);
        
        await Task.WhenAll(getOrderTask);
        
         OrderDetails orderDetails = new OrderDetails
        {
            OrderId = orderId,
            BuyerId = getOrderTask.Result.BuyerId,
            Address =
            $"{getOrderTask.Result.ShipToAddress.Street} " +
            $"{getOrderTask.Result.ShipToAddress.City} " +
            $"{getOrderTask.Result.ShipToAddress.State} " +
            $"{getOrderTask.Result.ShipToAddress.Country} " +
            $"{getOrderTask.Result.ShipToAddress.ZipCode}",
            OrderDate = getOrderTask.Result.OrderDate,
            Items = getOrderTask.Result.OrderItems.ToList(),
            Status = 0,
            TotalPrice = getOrderTask.Result.Total()
        };
        
        return orderDetails;
    }

    //
    public async Task<OrderDetails> Create(CreateOrderDetailsRequest orderDetails)
    {
        var response = await _httpService.HttpPost<CreateOrderDetailsResponse>("order-details", orderDetails);
        return response?.OrderDetails;
    }


    public async Task<string> Delete(int id)
    {
        return (await _httpService.HttpDelete<DeleteOrderDetailsResponse>("order-details", id)).Status;
    }

    public async Task<OrderDetails> Edit(OrderDetails orderDetails)
    {
        return (await _httpService.HttpPut<EditOrderDetailsResult>("order-details", orderDetails)).OrderDetails;
    }

    public async Task<OrderDetails> GetById(int id)
    {
        var detailGetTask = _httpService.HttpGet<EditOrderDetailsResult>($"order-details/{id}");
        await Task.WhenAll(detailGetTask);
        var response = detailGetTask?.Result.OrderDetails;
        return response;
    }

    public async Task<List<OrderDetails>> List()
    {
        var orders = (await _orderRepository.ListAsync()).OrderBy(x=>x.Id);

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

    public async Task<List<OrderDetails>> ListPaged(int pageSize)
    {
        var detailsListTask = _httpService.HttpGet<PagedOrderDetailsResponse>($"order-details?PageSize=10");
        await Task.WhenAll(detailsListTask);

        var details = detailsListTask.Result.OrderDetails;
        return details;
    }
}
