namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class GetOrderDetailsRequest : BaseRequest
{
    public int OrderId { get; init; }

    public GetOrderDetailsRequest(int orderId)
    {
        OrderId = orderId;
    }
}

