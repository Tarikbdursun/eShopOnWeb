using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models.OrderDetailsModels;
public  class PagedOrderListResponse
{
    public List<Order> OrderList { get; set; } = new List<Order>();
    public int PageCount { get; set; } = 0;
}
