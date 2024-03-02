using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;
using System.Threading.Tasks;

namespace ProjectReturn.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;

        private string _currentUserEmail;

        public OrderController(UserManager<AppUser> userManager, IAllOrders allOrders, ShopCart shopCart)
        {
            _userManager = userManager;
            _allOrders = allOrders;
            _shopCart = shopCart;
        }

        public async Task<IActionResult> Checkout()
        {
            
            var currentUser = await _userManager.GetUserAsync(User);

            
            if (currentUser == null)
            {
                
                return RedirectToAction("Login", "Account");
            }

           
            string userEmail = currentUser.Email;

           
            Order newOrder = new Order
            {
                email = userEmail
            };

            return View(newOrder);
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
           
            var currentUser = _userManager.GetUserAsync(User).Result;

            
            if (currentUser == null)
            {
                
                return RedirectToAction("Login", "Account");
            }

            
            string userEmail = currentUser.Email;

           
            if (order.email != userEmail)
            {
                
                ViewBag.ErrorMessage = "Email mismatch. Please make sure you are ordering with your own email address.";
                return View(order);
            }

           
            _shopCart.ListShopItems = _shopCart.getShopItems();

           
            if (_shopCart.ListShopItems.Count == 0)
            {
                ViewBag.ErrorMessage = "You must have a product in your cart before proceeding to checkout.";
                return View(order);
            }

           
            Order newOrder = new Order
            {
                Name = order.Name,
                Surname = order.Surname,
                email = userEmail,
                Adress = order.Adress,
                Phone = order.Phone
               
            };

            _allOrders.createOrder(newOrder);

            return RedirectToAction("Complete");
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Order Processed Successfully";
            return View();
        }

        public IActionResult OrderStatus(int id)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            _currentUserEmail = TempData["Email"] as string;

            var orders = _allOrders.GetOrderById(_currentUserEmail);

            if (orders != null)
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
            var order = _allOrders.GetOrderByUserEmail(email, orderId);

            if (order != null)
            {

                order.Status = newStatus;
                _allOrders.UpdateOrder(order);
                return RedirectToAction("AdminDashboard", "Home");
            }
            else
            {
                return RedirectToAction("NotFound", "Error");
            }
        }

    }
}
