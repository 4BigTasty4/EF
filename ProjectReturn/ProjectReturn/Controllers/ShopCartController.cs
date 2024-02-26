using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;
using ProjectReturn.ViewModels;

public class ShopCartController : Controller
{
    private readonly IAllCars _carRep;
    private readonly ShopCart _shopCart;
    private readonly UserManager<AppUser> _userManager;

    public ShopCartController(IAllCars carRep, ShopCart shopCart, UserManager<AppUser> userManager)
    {
        _carRep = carRep;
        _shopCart = shopCart;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var items = _shopCart.getShopItems();
        _shopCart.ListShopItems = items;

        var obj = new ShopCartViewModel
        {
            shopcart = _shopCart
        };

        return View(obj);
    }

    public async Task<IActionResult> addToCart(int id)
    {
        if (!User.Identity.IsAuthenticated)
        {
            // Перенаправляем анонимного пользователя на страницу входа
            return RedirectToAction("Login", "Account");
        }

        var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            var user = await _userManager.GetUserAsync(User);
            _shopCart.AddToCart(item, user.Id); // Передаем также идентификатор пользователя
        }
        return RedirectToAction("Index");
    }


    public IActionResult removeFromCart(int id)
    {
        _shopCart.RemoveFromCart(id); // Передаем идентификатор товара для удаления
        return RedirectToAction("Index");
    }
}
