using System.Collections.Generic;

namespace BlazorShared.Models.OrderDetailsModels;

public class PagedOrderDetailsResponse
{
    public List<OrderDetails> OrderDetailsList { get; set; } = new();
    public int PageCount { get; set; } = 0;
}
