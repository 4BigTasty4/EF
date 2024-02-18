using System.ComponentModel.DataAnnotations;

namespace ProjectReturn.ViewModels;

public class LoginViewModel
{
	[Required(ErrorMessage ="Username is Required")]
	public string Username { get; set; }

	[DataType(DataType.Password)]
	[Required(ErrorMessage ="Password is Required")]
	public string Password { get; set; }

	[Display(Name = "Remember Me")]
	public bool RememberMe { get; set; }
}
