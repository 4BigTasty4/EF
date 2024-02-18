using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectReturn.Data;
using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;
using System.Web.Mvc;

namespace ProjectReturn.Controllers;

public class OrderController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IAllOrders allOrders;
    private readonly ShopCart shopCart;

    public OrderController(IAllOrders allOrders, ShopCart shopCart)
    {
        this.allOrders = allOrders;
        this.shopCart = shopCart;
    }

    public IActionResult Checkout()
    {
        return View();
    }

	[Microsoft.AspNetCore.Mvc.HttpPost]
	public IActionResult Checkout(Order order)
	{
        shopCart.ListShopItems = shopCart.getShopItems();

        if(shopCart.ListShopItems.Count == 0)
        {
            ModelState.AddModelError("", "You Must Have a Product");
            ViewData["ErrorMessage"] = "You must have a product in your cart before proceeding to checkout.";
            return View();
        }

		ModelState.Remove("orderDetails");

		if (ModelState.IsValid)
        {
            //allOrders.createOrder(order);
            return RedirectToAction("Complete");
        }
        return View(order);
    }

	public IActionResult Complete()
    {
        ViewBag.Message = "Order Processed Successfully";
        return View();
	}

}
