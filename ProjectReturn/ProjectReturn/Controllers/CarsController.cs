using Microsoft.AspNetCore.Mvc;
using ProjectReturn.Data.Interfaces;
using ProjectReturn.ViewModels;

namespace ProjectReturn.Controllers;

public class CarsController : Controller
{
    private readonly IAllCars _allCars;
    private readonly ICarsCategory _allCategories;

    public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
    {
        _allCars = iAllCars;
        _allCategories = iCarsCat;
    }

    public ViewResult List()
    {
        ViewBag.Title = "Cars page";
		CarsListViewModel obj = new CarsListViewModel();
        obj.allCars = _allCars.Cars;
        obj.currCategory = "Autos";

        return View(obj);
    }
}
