using System.Collections.Generic;
using ProjectReturn.Data.Model;

public class UserOrderStatusViewModel
{
	public string UserId { get; set; }
	public string UserName { get; set; }
	public List<Order> Orders { get; set; }
}
