using System.Collections.Generic;
using ProjectReturn.Data.Model;

namespace ProjectReturn.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order);
        Order GetOrderById(int id);
        void UpdateOrder(Order order);
        Order GetOrderByUserEmail(string email, int orderId); // Добавляем метод для получения заказа по электронной почте пользователя и идентификатору заказа
        List<Order> GetOrdersByUserId(int userId); // Добавляем метод для получения всех заказов пользователя по его идентификатору
        List<Order> GetOrdersByEmail(string email);
    }
}
