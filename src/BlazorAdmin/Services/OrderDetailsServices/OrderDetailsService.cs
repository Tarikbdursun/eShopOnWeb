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
    private readonly ILogger<CatalogItemService> _logger;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.OrderDetails> _orderDetailsRepository;

    public OrderDetailsService(
        HttpService httpService, 
        ILogger<CatalogItemService> logger, 
        IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.OrderDetails> orderDetailsRepository, 
        IRepository<Order> orderRepository)
    {
        _httpService = httpService;
        _logger = logger;
        _orderDetailsRepository = orderDetailsRepository;
        _orderRepository = orderRepository;
    }

    public async Task<OrderDetails> GetByOrderIdAsync(int orderId) 
    {
        var getOrderTask= _orderRepository.GetByIdAsync(orderId);
        
        await Task.WhenAll(getOrderTask);

        //
        //_orderDetailsRepository.FirstOrDefaultAsync(x => x.OrderId == orderId);
        
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
            Status = "Pending",
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
        _logger.LogInformation("Fetching order details from API.");

        var detailsListTask = _httpService.HttpGet<PagedOrderDetailsResponse>($"order-details");
        await Task.WhenAll(detailsListTask);

        var details = detailsListTask.Result.OrderDetails;
        return details;
    }

    public async Task<List<OrderDetails>> ListPaged(int pageSize)
    {
        _logger.LogInformation("Fetching order details from API.");

        var detailsListTask = _httpService.HttpGet<PagedOrderDetailsResponse>($"order-details?PageSize=10");
        await Task.WhenAll(detailsListTask);

        var details = detailsListTask.Result.OrderDetails;
        return details;
    }
}
