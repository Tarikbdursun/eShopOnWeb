using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models.OrderDetailsModels;
public class EditOrderDetailsResult
{
    public OrderDetails OrderDetails { get; set; } = new OrderDetails();
}
