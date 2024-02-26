using Microsoft.EntityFrameworkCore;

namespace ProjectReturn.Data.Model;

public class ShopCart
{
    private readonly AppDBContent appDBContent;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public string ShopCartId { get; private set; }
    public List<ShopCartItem> ListShopItems { get; set; }

    public ShopCart(AppDBContent appDBContent, IHttpContextAccessor httpContextAccessor)
    {
        this.appDBContent = appDBContent;
        _httpContextAccessor = httpContextAccessor;

     
        ShopCartId = _httpContextAccessor.HttpContext.Session.GetString("CartId") ?? Guid.NewGuid().ToString();
        _httpContextAccessor.HttpContext.Session.SetString("CartId", ShopCartId);

        
        ListShopItems = appDBContent.ShopCartItem
                                      .Where(item => item.ShopCartId == ShopCartId)
                                      .Include(item => item.car)
                                      .ToList();
    }

    public void AddToCart(Car car, string userId)
    {
        var shopCartItem = new ShopCartItem
        {
            ShopCartId = ShopCartId,
            car = car,
            price = car.price,
            UserId = userId
        };

        appDBContent.ShopCartItem.Add(shopCartItem);
        appDBContent.SaveChanges();

        ListShopItems.Add(shopCartItem);
    }
    public List<ShopCartItem> getShopItems()
    {
        return appDBContent.ShopCartItem
                            .Where(c => c.ShopCartId == ShopCartId)
                            .Include(s => s.car)
                            .ToList();
    }

    public void RemoveFromCart(int carId)
    {
        var item = ListShopItems.FirstOrDefault(item => item.car.Id == carId);
        if (item != null)
        {
            appDBContent.ShopCartItem.Remove(item);
            appDBContent.SaveChanges();

            ListShopItems.Remove(item); 
        }
    }
}
