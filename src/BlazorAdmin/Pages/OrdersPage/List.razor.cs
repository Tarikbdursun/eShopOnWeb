using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorAdmin.Services;
using BlazorAdmin.Services.OrderDetailsServices;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using BlazorShared.Models.OrderDetailsModels;
using Microsoft.AspNetCore.Components;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace BlazorAdmin.Pages.OrdersPage;

public partial class List : BlazorComponent
{
    //[Microsoft.AspNetCore.Components.Inject]
    //public IOrderDetailsService OrderDetailsService { get; set; }
    [Inject]
    private IOrderDetailsService OrderDetailsService { get; set; }

   

    //private readonly IOrderDetailsService _orderDetailsService;

    //[Microsoft.AspNetCore.Components.Inject]
    //public IOrderDetailsService OrderDetailsService { get; set; }

    //public List(IOrderDetailsService orderDetailsService)
    //{
    //    _orderDetailsService = orderDetailsService;
    //}

    private List<OrderDetails> orderDetails;

    protected override async Task OnInitializedAsync()
    {
        orderDetails = await OrderDetailsService.List();//await _orderDetailsService.List(); 
    }


    private async Task ListClick()
    {
        //orderDetails = await _orderDetailsService.List();
    }
    ////Maybe we need it 
    //[Microsoft.AspNetCore.Components.Inject]
    //public IOrderService OrderService { get; set; }

    //private List<OrderDetails> orderDetails = new List<OrderDetails>();

    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //    if (firstRender)
    //    {
    //        orderDetails = await OrderDetailsService.List();
    //        CallRequestRefresh();
    //    }

    //    await base.OnAfterRenderAsync(firstRender);
    //}


    //private async void DetailsClick(int id)
    //{
    //    await DetailsComponent.Open(id);
    //}
}
