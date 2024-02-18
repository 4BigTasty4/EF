namespace ProjectReturn.Data.Model;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Car> cars { get; set; }

}
