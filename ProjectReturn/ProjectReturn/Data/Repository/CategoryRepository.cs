using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Model;

namespace ProjectReturn.Data.Repository;

public class CategoryRepository : ICarsCategory
{
	private readonly AppDBContent appDBContent;

	public CategoryRepository(AppDBContent appDBContent)
	{
		this.appDBContent = appDBContent;
	}

	public IEnumerable<Category> AllCategories => appDBContent.Category;
}
