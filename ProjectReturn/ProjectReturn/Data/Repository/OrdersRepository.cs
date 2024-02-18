using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;

namespace ProjectReturn.Data.Repository;

public class OrdersRepository : IAllOrders
{

    private readonly AppDBContent appDBContent;
    private readonly ShopCart shopCart;

    public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
    {
        this.appDBContent = appDBContent;
        this.shopCart = shopCart;
    }

    public void createOrder(Order order)
    {
        order.orderTime = DateTime.Now;
        appDBContent.Order.Add(order);

        var items = shopCart.ListShopItems;

        foreach (var el in items)
        {
            var orderDetail = new OrderDetail()
            {
                CarID = el.car.Id,
                orderID = order.Id,
                price = el.car.price
            };
            appDBContent.OrderDetail.Add(orderDetail);
        }
        appDBContent.SaveChanges();
    }
}
