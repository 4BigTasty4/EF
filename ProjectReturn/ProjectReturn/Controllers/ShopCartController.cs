using Microsoft.AspNetCore.Mvc;
using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;
using ProjectReturn.ViewModels;

namespace ProjectReturn.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public IActionResult Index()
        {
            var item = _shopCart.getShopItems();
            _shopCart.ListShopItems = item;

            var obj = new ShopCartViewModel
            {
                shopcart = _shopCart
            };

            return View(obj);
        }

        public IActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
