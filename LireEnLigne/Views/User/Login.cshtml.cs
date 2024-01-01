using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LireEnLigne.Views.User
{
    public class LoginModel 
    {
		[Required]
		public required string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public required string Password { get; set; }
		/*  public void OnGet()
		  {
		  }*/
	}
}
