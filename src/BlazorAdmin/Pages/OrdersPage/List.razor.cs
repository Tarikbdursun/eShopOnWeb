using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorShared.Interfaces;
using BlazorShared.Models.OrderDetailsModels;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;


namespace BlazorAdmin.Pages.OrdersPage;

public partial class List : BlazorComponent
{
    [Microsoft.AspNetCore.Components.Inject]
    public IOrderDetailsService OrderDetailsService { get; set; }

    private List<Order> orderDetails=new List<Order>();

    protected override async Task OnInitializedAsync()
    {
        orderDetails = await OrderDetailsService.List();
    }
    
}
