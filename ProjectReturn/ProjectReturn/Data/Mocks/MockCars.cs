using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;

namespace ProjectReturn.Data.Mocks;

public class MockCars : IAllCars
{

    private readonly ICarsCategory _categoryCars = new MockCategory();

    public IEnumerable<Car> Cars
    {
        get
        {
            return new List<Car>
            {
                new Car
                {
                    Name = "Ford", LongDesc = "beautiful", ShortDesc = "speed",image = "/img/ford.jpg",price = 30000,isFavourite = true,avaiLable = true, Category = _categoryCars.AllCategories.First()
                },
                new Car
                {
                    Name = "Tesla",LongDesc = "Cypher", ShortDesc = "Big",image = "/img/cyber.jpg" ,price = 50000,isFavourite=true,avaiLable = true,Category = _categoryCars.AllCategories.Last()
                }
            };
        }
    }
    public IEnumerable<Car> getFavCars { get ; set ; }

    public Car getObjectCar(int carId)
    {
        throw new NotImplementedException();
    }
}
