using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorAdmin.Services.OrderDetailsServices;
using BlazorShared.Models.OrderDetailsModels;
using Microsoft.AspNetCore.Components;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Services;

namespace BlazorAdmin.Pages.OrdersPage;

partial class Details:BlazorComponent
{
    [Parameter]
    public int orderId { get; set; }

    [Inject]
    public OrderDetailsService OrderDetailsService { get; set; }
    [Inject]
    public IOrderService OrderService{ get; set; }

    private List<OrderDetailsModel> OrderItems { get; set; }

    protected override async Task OnInitializedAsync()
    {
        OrderItems = await OrderDetailsService.ListDetails(orderId);
    }

    public async Task ApproveOrder()
    {
        // Sipariş durumunu approve olarak değiştirmek için servise istek gönder
        await OrderService.SetOrderStatus(orderId,1);
        // İşlem tamamlandıktan sonra gerekli işlemleri yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz
        // MessageBox.Show("Sipariş onaylandı!");
    }

    //public class OrderItemViewModel
    //{
    //    public CatalogItemOrderedViewModel CatalogItemOrdered { get; set; }
    //    public decimal UnitPrice { get; set; }
    //    public int Units { get; set; }

    //    // TotalPrice hesaplaması gerekirse
    //    public decimal TotalPrice => Units * UnitPrice;
    //}

    //public class CatalogItemOrderedViewModel
    //{
    //    public string ProductName { get; set; }
    //    public string PictureUri { get; set; }
    //}
}
