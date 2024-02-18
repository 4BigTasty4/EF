using ProjectReturn.Data.Model;

namespace ProjectReturn.Data;

public class DBObjects
{
	public static void Initial(AppDBContent content)
	{
		if(!content.Category.Any()) 
			content.Category.AddRange(Categories.Select(c => c.Value));
		if (!content.Car.Any())
		{
			content.AddRange(
				new Car
				{
					Name = "Ford",
					LongDesc = "beautiful",
					ShortDesc = "speed",
					image = "/img/ford.jpg",
					price = 30000,
					isFavourite = true,
					avaiLable = true,
					Category = Categories["Sport"]
				},
				new Car
				{
					Name = "Tesla",
					LongDesc = "Cypher",
					ShortDesc = "Big",
					image = "/img/cyber.jpg",
					price = 50000,
					isFavourite = true,
					avaiLable = true,
					Category = Categories["Elektro"]
				}
			);
		}

		content.SaveChanges();

	}

	private static Dictionary<string, Category> category;

	public static Dictionary<string,Category> Categories
	{
		get
		{
			if(category == null)
			{
				var list = new Category[]
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
				category = new Dictionary<string, Category>();
                foreach (Category el in list)
                {
					category.Add(el.Name, el);
                }
            }
			return category;	
		}
	}

}
