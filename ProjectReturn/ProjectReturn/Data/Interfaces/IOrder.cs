using ProjectReturn.Data.Model;

namespace ProjectReturn.Data.Interfaces;

public interface IOrder
{
    Task<Order> AdminDashboard(Order order);
}
