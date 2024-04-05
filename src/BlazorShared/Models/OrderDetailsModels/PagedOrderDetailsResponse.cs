using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models.OrderDetailsModels;
public  class PagedOrderDetailsResponse
{
    public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    public int PageCount { get; set; } = 0;
}
