using System.Collections.Generic;
using ProjectReturn.Data.Model;

namespace ProjectReturn.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order);
        Order GetOrderById(string id);
        void UpdateOrder(Order order);
        Order GetOrderByUserEmail(string email, int orderId);
    }
}
