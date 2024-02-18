using ProjectReturn.Data.Model;

namespace ProjectReturn.Data.Interfaces;

public interface IAllCars
{
    IEnumerable<Car> Cars { get; }
    IEnumerable<Car> getFavCars { get; }
    Car getObjectCar(int carId);
}
