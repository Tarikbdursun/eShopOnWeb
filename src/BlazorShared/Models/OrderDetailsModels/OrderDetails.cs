using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace BlazorShared.Models.OrderDetailsModels;
public class OrderDetails
{
    public CatalogItemOrdered CatalogItemOrdered { get; set; }
    public string CatalogItemOrderedName => CatalogItemOrdered.ProductName;
    public string CatalogItemOrderedPicUri => CatalogItemOrdered.PictureUri;
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Units * UnitPrice;
    public int Units { get; set; }
}
