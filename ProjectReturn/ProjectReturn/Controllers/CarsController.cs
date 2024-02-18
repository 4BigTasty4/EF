using Microsoft.AspNetCore.Mvc;
using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;
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

    [Route("Cars/List")]
    [Route("Cars/List/{category}")]
    public ViewResult List(string category)
    {

        string _category = category;
        IEnumerable<Car> cars = null;
        string currCategory = "";
        if (string.IsNullOrEmpty(category))
        {
            cars = _allCars.Cars.OrderBy(i => i.Id);
        }
        else
        {
            if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(i => i.Category.Name.Equals("Elektro")).OrderBy(i => i.Id);    
                currCategory = "Elektro";
            }
            else if(string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(i => i.Category.Name.Equals("Sport")).OrderBy(i => i.Id);
                currCategory = "Sport";
            }

        }

        var carObj = new CarsListViewModel
        {
            allCars = cars,
            currCategory = currCategory,
        };

        ViewBag.Title = "Cars page";
		

        return View(carObj);
    }
}
