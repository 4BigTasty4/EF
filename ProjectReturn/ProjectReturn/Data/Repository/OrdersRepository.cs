using System.Collections.Generic;
using System.Linq;
using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;

namespace ProjectReturn.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent _appDBContent;

        public OrdersRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public void createOrder(Order order)
        {
            _appDBContent.Order.Add(order);
            _appDBContent.SaveChanges();
        }

        public Order GetOrderById(string id) => _appDBContent.Order.FirstOrDefault(o => o.email == id);

        public void UpdateOrder(Order order)
        {
            _appDBContent.Order.Update(order);
            _appDBContent.SaveChanges();
        }

        public Order GetOrderByUserEmail(string email, int orderId)
        {
            return _appDBContent.Order.FirstOrDefault(o => o.Id == orderId);
        }

    }
}
