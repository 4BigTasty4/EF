using ProjectReturn.Data.Model;

namespace ProjectReturn.ViewModels;

public class CarsListViewModel
{
	public IEnumerable<Car> allCars {  get; set; }
	public string currCategory { get; set; }
}
