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
    [Inject]
    public IOrderDetailsService OrderDetailsService { get; set; }
    [Inject]
    public IOrderService OrderService{ get; set; }
    
    [Parameter]
    public int OrderId { get; set; }
    private List<OrderDetailsModel> OrderItems { get; set; } = new List<OrderDetailsModel>();

    //protected override void OnInitialized()
    //{
    //    if (orderId == 1)
    //    {
    //        var odmList = new List<OrderDetailsModel>
    //        {
    //            new OrderDetailsModel
    //              {
    //                CatalogItemOrdered = new Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate
    //                .CatalogItemOrdered(orderId = 1, "Abc", "/images/products/3.png"),
    //                UnitPrice = 15,
    //                Units = 2
    //              }
    //        };
    //        OrderItems = odmList;
    //    }
    //    base.OnInitialized();
    //}

    protected override async Task OnInitializedAsync()
    {

       
        var odmList = new List<OrderDetailsModel>
                    {
                        new OrderDetailsModel
                          {
                            CatalogItemOrdered = new Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate
                            .CatalogItemOrdered(1, "Abc", "/images/products/3.png"),
                            UnitPrice = 15,
                            Units = 2
                          }
                    };
        OrderItems = odmList;
        
        await Task.CompletedTask;
        await OrderDetailsService.ListDetails(OrderId);

    }

    public async Task ApproveOrder()
    {

        //// Sipariş durumunu approve olarak değiştirmek için servise istek gönder
        await OrderService.SetOrderStatus(OrderId, 1);
        //// İşlem tamamlandıktan sonra gerekli işlemleri yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz
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
