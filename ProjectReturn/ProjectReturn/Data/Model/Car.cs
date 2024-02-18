namespace ProjectReturn.Data.Model;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortDesc { get; set; }
    public string LongDesc { get; set; }
    public string image {  get; set; }
    public ushort price { get; set; }
    public bool isFavourite { get; set; }
    public bool avaiLable { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}
