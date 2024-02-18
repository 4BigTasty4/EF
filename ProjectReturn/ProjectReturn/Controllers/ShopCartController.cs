using Microsoft.AspNetCore.Mvc;
using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;
using ProjectReturn.Data.Repository;
using ProjectReturn.ViewModels;
using System.Web.Mvc;

namespace ProjectReturn.Controllers;

public class ShopCartController : Microsoft.AspNetCore.Mvc.Controller
{
	private IAllCars _carRep;
	private readonly ShopCart _shopCart;

	public RedirectToActionResult RedirectToAction { get; private set; }

	public ShopCartController(IAllCars carRep, ShopCart shopCart)
	{
		_carRep = carRep;
		_shopCart = shopCart;
	}

	public Microsoft.AspNetCore.Mvc.ViewResult Index()
	{
		var item = _shopCart.getShopItems();
		_shopCart.ListShopItems = item;

		var obj = new ShopCartViewModel
		{
			shopcart = _shopCart
		};

		return View(obj);

	}

	public RedirectToActionResult addToCart(int id)
	{
		var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);
		if (item != null)
		{
			_shopCart.AddToCart(item);
		}
		return RedirectToAction("Index");	}
}
