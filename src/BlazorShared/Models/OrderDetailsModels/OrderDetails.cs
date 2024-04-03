﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorInputFile;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace BlazorShared.Models.OrderDetailsModels;
public class OrderDetails
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string BuyerId { get; set; }

    [Required(ErrorMessage = "The Name field is required")]
    public string BuyerName { get; set; }

    [Required(ErrorMessage = "The Address field is required")]
    public string Address { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItem> Items { get; set; }

    [RegularExpression(@"^\d+(\.\d{0,2})*$", ErrorMessage = "The field Price must be a positive number with maximum two decimals.")]
    [Range(0.01, 1000)]
    [DataType(DataType.Currency)]
    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = "Pending";
}
