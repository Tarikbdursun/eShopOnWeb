using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models.OrderDetailsModels;

namespace BlazorShared.Interfaces;
public interface IOrderDetailsService
{
    //Task<OrderDetails> Create(CreateOrderDetailsRequest catalogItem);
    //Task<OrderDetails> Edit(OrderDetails orderDetails);
    //Task<string> Delete(int id);
    //Task<OrderDetails> GetById(int id);
    //Task<List<OrderDetails>> ListPaged(int pageSize);


    Task<List<Order>> List();
    Task<List<OrderDetails>> ListDetails(int orderId);
    Task SetOrderStatus(int orderId, short status);
}
