using System.Collections.Generic;
using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class GetOrderDetailsResponse : BaseResponse
{
    public GetOrderDetailsResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GetOrderDetailsResponse()
    {
    }

    public List<OrderDetailsDto> OrderDetails { get; set; } = new List<OrderDetailsDto>();
}

