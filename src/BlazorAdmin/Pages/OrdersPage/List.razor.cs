using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorAdmin.Services;
using BlazorAdmin.Services.OrderDetailsServices;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using BlazorShared.Models.OrderDetailsModels;
using Microsoft.AspNetCore.Components;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Infrastructure.Data;

namespace BlazorAdmin.Pages.OrdersPage;

public partial class List : BlazorComponent
{
    //[Inject]
    //public IOrderDetailsService OrderDetailsService { get; set; }

    private List<OrderDetails> orderDetails;

    protected override async Task OnInitializedAsync()
    {
        //OrderDetailsService = new OrderDetailsService(new EfRepository<Order>(new CatalogContext(new Microsoft.EntityFrameworkCore.DbContextOptions<CatalogContext>())));
        List<OrderDetails> orderDetails = new List<OrderDetails>();

        var od = new OrderDetails
        {
            Address = "assaff",
            BuyerId = "1223",
            Items = null,
            OrderDate = DateTime.Now,
            OrderId = 1,
            TotalPrice = 10,
            Status = 0
        };

        orderDetails.Add(od);


        this.orderDetails = orderDetails;//await OrderDetailsService.List();
    }
}
