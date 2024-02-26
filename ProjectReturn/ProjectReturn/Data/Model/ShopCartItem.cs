namespace ProjectReturn.Data.Model;

public class ShopCartItem
{
	public int id { get; set; }
    public string UserId { get; set; }
    public Car car { get; set; }
	public int price { get; set; }
	public string ShopCartId { get; set; }
}
