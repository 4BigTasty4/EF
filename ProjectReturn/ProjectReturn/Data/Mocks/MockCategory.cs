using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;

namespace ProjectReturn.Data.Mocks;

public class MockCategory : ICarsCategory
{
    public IEnumerable<Category> AllCategories
    {
        get
        {
            return new List<Category>
            {
                new Category
                {
                    Name = "Sport",Description = "Benzin"
                },
                new Category
                {
                    Name= "Elektro",Description = "Tok"
                }
            };
        }
    }
}
