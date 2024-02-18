using ProjectReturn.Data.Model;

namespace ProjectReturn.Data.Interfaces;

public interface ICarsCategory 
{
    IEnumerable<Category> AllCategories { get; }
}
