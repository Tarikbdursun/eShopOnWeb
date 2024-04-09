using System.Collections.Generic;
using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class ListPagedOrderResponse : BaseResponse
{
    public ListPagedOrderResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListPagedOrderResponse()
    {
    }

    public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    public int PageCount { get; set; }
}
