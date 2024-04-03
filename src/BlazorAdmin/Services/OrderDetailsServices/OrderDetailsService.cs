using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using BlazorShared.Models.OrderDetailsModels;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Services;
using Microsoft.Extensions.Logging;

namespace BlazorAdmin.Services.OrderDetailsServices;

public class OrderDetailsService : IOrderDetailsService
{
    private readonly HttpService _httpService;
    private readonly ILogger<CatalogItemService> _logger;

    public OrderDetailsService(HttpService httpService, ILogger<CatalogItemService> logger)
    {
        _httpService = httpService;
        _logger = logger;

    }

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

    public Task<OrderDetails> GetById(int id)
    {
        
        //var orderListTask = _orderService.List();
        //var brandListTask = 
        //var typeListTask = _typeService.List();
        //var itemGetTask = _httpService.HttpGet<EditCatalogItemResult>($"catalog-items/{id}");
        //await Task.WhenAll(brandListTask, typeListTask, itemGetTask);
        //var brands = brandListTask.Result;
        //var types = typeListTask.Result;
        //var catalogItem = itemGetTask.Result.CatalogItem;
        //catalogItem.CatalogBrand = brands.FirstOrDefault(b => b.Id == catalogItem.CatalogBrandId)?.Name;
        //catalogItem.CatalogType = types.FirstOrDefault(t => t.Id == catalogItem.CatalogTypeId)?.Name;
        //return catalogItem;
        return new Task<OrderDetails>(null);
    }

    public Task<List<OrderDetails>> List()
    {
        throw new System.NotImplementedException();
    }

    public Task<List<OrderDetails>> ListPaged(int pageSize)
    {
        throw new System.NotImplementedException();
    }
}
