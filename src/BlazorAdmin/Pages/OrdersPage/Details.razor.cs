using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorShared.Interfaces;
using BlazorShared.Models.OrderDetailsModels;
using Microsoft.AspNetCore.Components;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace BlazorAdmin.Pages.OrdersPage;

partial class Details : BlazorComponent
{
    [Microsoft.AspNetCore.Components.Inject]
    public IOrderDetailsService OrderDetailsService { get; set; }
    
    [Parameter]
    public int OrderId { get; set; }
    private List<OrderDetails> orderItems = new List<OrderDetails>();

    protected override async Task OnInitializedAsync()
    {
        orderItems = await OrderDetailsService.ListDetails(OrderId);
    }

    public async Task ApproveOrder()
    {
        await OrderDetailsService.SetOrderStatus(OrderId, 1);   
    }
}
