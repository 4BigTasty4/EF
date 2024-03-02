using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectReturn.Data;
using ProjectReturn.Data.Model;
using ProjectReturn.Migrations;
using ProjectReturn.ViewModels;
using ShopCart = ProjectReturn.Data.Model.ShopCart;
using ShopCartItem = ProjectReturn.Data.Model.ShopCartItem;

namespace ProjectReturn.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<AppUser> signInManager;
    private readonly UserManager<AppUser> userManager;
    private readonly ShopCart _shopCart;
    private readonly AppDBContent _appDBContent;


    public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ShopCart shopCart, AppDBContent appDBContent)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        _shopCart = shopCart;
        _appDBContent = appDBContent;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);

            var user = await userManager.GetUserAsync(User);

            if (result.Succeeded && user != null)
            {
                if (model.Username == "Admin" && model.Password == "Admin1234")
                {
                    return RedirectToAction("AdminDashboard", "Home");
                }
                TempData["Email"] = user.Email;
                return RedirectToAction("Index", "Home");
            }

            //await signInManager.RefreshSignInAsync(user);
            ModelState.AddModelError("", "Invalid login attempt");
        }
        return View(model);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            AppUser user = new()
            {
                Name = model.Name,
                UserName = model.Name,
                Email = model.Email,
                Address = model.Address
            };

            var result = await userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, true);

                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        var user = await userManager.GetUserAsync(User);

        foreach (var item in _shopCart.getShopItems())
        {
            _shopCart.RemoveFromCart(item.car.Id);
        }

        await signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}
