using API.Common.DTO;
using System.Collections.Generic;

namespace SalesAPI.Domain.Abstract
{
    public interface IOrderEntity
    {
        void AddOrder(Order OR);
        void DeleteOrder(int id);
        List<Order> getListofAllOrders();
        Order GetOrderById2(int id);
        void UpdateOrder(Order OR);
    }
}