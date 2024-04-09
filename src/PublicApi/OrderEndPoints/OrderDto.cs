using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class OrderDto
{
    public int OrderId { get; set; }
    public string BuyerId { get; set; }
    public string Address { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal TotalPrice { get; set; }
    public short Status { get; set; }
}
