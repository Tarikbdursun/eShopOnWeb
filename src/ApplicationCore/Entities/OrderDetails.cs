using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Services;

namespace Microsoft.eShopWeb.ApplicationCore.Entities;
public class OrderDetails:BaseEntity, IAggregateRoot
{
    public int OrderId { get; private set; }
    public string Status { get; set; }
    public int BuyerId { get; set; }
    public string Address { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal TotalPrice { get; set; }

#pragma warning disable CS8618 // Required by Entity Framework
    private OrderDetails() { }
    public OrderDetails(int orderId)
    {
        Guard.Against.OutOfRange(orderId, nameof(orderId), 1, int.MaxValue);

        OrderId = orderId;
        Status = "Pending";
    }
}


