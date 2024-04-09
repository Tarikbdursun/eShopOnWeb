using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class OrderDetailsDto
{
    public CatalogItemOrdered CatalogItemOrdered { get; set; }
    public decimal UnitPrice { get; set; }
    public int Units { get; set; }
}
