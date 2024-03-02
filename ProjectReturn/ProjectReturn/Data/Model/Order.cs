using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjectReturn.Data.Model;

public enum OrderStatus
{
    Pending,        
    Processing,     
    Completed,      
    Cancelled       
                    
}

public class Order
{
	[BindNever]
	public int Id { get; set; }

	[Display(Name = "Input Name")]
	[StringLength(25)]
	[Required(ErrorMessage = "Name Length at Least 5 Characters")]
	public string Name { get; set; }

	[Display(Name = "Input Surname")]
	[StringLength(25)]
	[Required(ErrorMessage = "Surname Length at Least 5 Characters")]
	public string Surname { get; set; }

	[Display(Name = "Input Adress")]
	[StringLength(25)]
	[Required(ErrorMessage = "Adress Length at Least 5 Characters")]
	public string Adress { get; set; }

	[Display(Name = "Input Phone Number")]
	[DataType(DataType.PhoneNumber)]
	[StringLength(25)]
	[Required(ErrorMessage = "Phone Number Length at Least 5 Characters")]
	public string Phone { get; set; }

	[Display(Name = "Input email")]
	[DataType(DataType.EmailAddress)]
	[StringLength(25)]
	[Required(ErrorMessage = "email Length at Least 5 Characters")]
	public string email { get; set; }

    [Display(Name = "Order Status")]
    public OrderStatus Status { get; set; }

    public DateTime orderTime { get; set; }
	public List<OrderDetail> orderDetails { get; set; }
}
