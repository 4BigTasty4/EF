using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectReturn.Data;
using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;
using System.Security.Claims;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProjectReturn.Controllers;

public class OrderController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IAllOrders allOrders;
    private readonly ShopCart shopCart;
    private readonly UserManager<AppUser> userManager;

    public OrderController(IAllOrders allOrders, ShopCart shopCart, UserManager<AppUser> userManager)
    {
        this.allOrders = allOrders;
        this.shopCart = shopCart;
        this.userManager = userManager;
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
            allOrders.createOrder(order);
            return RedirectToAction("Complete");
        }
        return View(order);
    }

	public IActionResult Complete()
    {
        ViewBag.Message = "Order Processed Successfully";
        return View();
	}

    public IActionResult OrderStatus(string email)
    {
        var orders = allOrders.GetOrdersByEmail(email);

        if (orders != null && orders.Any())
        {
            return View(orders);
        }
        else
        {
            return RedirectToAction("NotFound", "Error");
        }
    }


    public IActionResult ChangeOrderStatus(int orderId, OrderStatus newStatus, string email)
    {
        
        var order = allOrders.GetOrderByUserEmail(email, orderId);

        if (order != null)
        {
           
            order.Status = newStatus;
            allOrders.UpdateOrder(order);
            return RedirectToAction("AdminDashboard", "Home");
        }
        else
        {
            return RedirectToAction("NotFound", "Error");
        }
    }
}
