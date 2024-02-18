using System.ComponentModel.DataAnnotations;

namespace ProjectReturn.ViewModels;

public class RegisterViewModel
{
	[Required]
	public string Name { get; set; }

	[Required]
	[DataType(DataType.EmailAddress)]
	public string Email { get; set; }

	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }

	[DataType(DataType.Password)]
	[Compare("Password",ErrorMessage ="Password dont Match")]
	[Display(Name = "Confirm Password")]
	public string ConfirmPassword { get; set; }

	[DataType(DataType.MultilineText)]
	public string Address { get; set; }
}
