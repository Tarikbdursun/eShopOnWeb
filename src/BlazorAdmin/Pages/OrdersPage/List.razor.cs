using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorShared.Interfaces;
using BlazorShared.Models.OrderDetailsModels;


namespace BlazorAdmin.Pages.OrdersPage;

public partial class List : BlazorComponent
{
    [Microsoft.AspNetCore.Components.Inject]
    public IOrderDetailsService OrderDetailsService { get; set; }

    private List<Order> orderDetails=new List<Order>();



    protected override async Task OnInitializedAsync()
    {
        //OrderDetailsService = new OrderDetailsService(new EfRepository<Order>(new CatalogContext(new Microsoft.EntityFrameworkCore.DbContextOptions<CatalogContext>())));
        //List<OrderDetails> orderDetails = new List<OrderDetails>();

        //var od = new OrderDetails
        //{
        //    Address = "assaff",
        //    BuyerId = "1223",
        //    Items = null,
        //    OrderDate = DateTime.Now,
        //    OrderId = 1,
        //    TotalPrice = 10,
        //    Status = 0
        //};

        //orderDetails.Add(od);

        orderDetails = await OrderDetailsService.List();
    }
    
}
