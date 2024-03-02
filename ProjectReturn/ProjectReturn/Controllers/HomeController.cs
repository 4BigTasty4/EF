using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectReturn.Data;
using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;
using ProjectReturn.Models;
using ProjectReturn.ViewModels;
using System.Diagnostics;

namespace ProjectReturn.Controllers;

public class HomeController : Controller
{
    private IAllCars _carRep;

    private string _currentUserId;

    private readonly AppDBContent _dbContext;

    List<AppUser> _users;
    List<Order> _orders;
    List<Car> _cars;
    List<Category> _categories;


    public HomeController(IAllCars carRep, AppDBContent dbContext)
    {
        _carRep = carRep;
        _dbContext = dbContext;
    }

    public ViewResult AdminDashboard()
    {
        List<AppUser> _users = _dbContext.AppUser.ToList();
        List<Order> _orders = _dbContext.Order.ToList();
        List<Car> _cars = _dbContext.Car.ToList();
        List<Category> _categories = _dbContext.Category.ToList();

        var result = new AdminDashboardViewModel
        {
            AppUsers = _users,
            Orders = _orders,
            Cars = _cars,
            Categories = _categories
        };

        return View(result);
    }

    public ViewResult Index()
    {
        var homeCars = new HomeViewModel
        {
            favCars = _carRep.getFavCars
        };
        return View(homeCars);
    }

}