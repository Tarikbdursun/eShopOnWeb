using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities;
public class OrderDetails:BaseEntity, IAggregateRoot
{
    public int OrderId { get; private set; }
    public string Status { get; set; }

#pragma warning disable CS8618 // Required by Entity Framework
    private OrderDetails() { }
    public OrderDetails(int orderId)
    {
        Guard.Against.OutOfRange(orderId, nameof(orderId), 1, int.MaxValue);

        OrderId = orderId;
        Status = "Pending";
    }
}


