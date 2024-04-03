using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;
using BlazorShared.Models.OrderDetailsModels;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace BlazorShared.Interfaces;
public interface IOrderDetailsService
{
    Task<OrderDetails> Create(CreateOrderDetailsRequest catalogItem);
    Task<OrderDetails> Edit(OrderDetails orderDetails);
    Task<string> Delete(int id);
    Task<OrderDetails> GetById(int id);
    Task<List<OrderDetails>> ListPaged(int pageSize);
    Task<List<OrderDetails>> List();
}
