using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorAdmin.Services;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using BlazorShared.Models.OrderDetailsModels;
using Microsoft.AspNetCore.Components;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace BlazorAdmin.Pages.OrderDetailsPage;

public partial class List//:BlazorComponent
{
    //[Inject]
    //public IOrderDetailsService OrderDetailsService { get; set; }

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

    //private async void ListClick()
    //{
    //    await OrderDetailsService.List();
    //}

    //private async void DetailsClick(int id)
    //{
    //    await DetailsComponent.Open(id);
    //}
}
