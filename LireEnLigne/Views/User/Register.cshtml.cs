using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LireEnLigne.Views.User
{
    public class RegisterModel
	{ 
		
			[Required]
			public required string Nom { get; set; }

			[Required]
			public required string Prenom { get; set; }

			[Required]
			public required string NumeroTelephone { get; set; }

			[Required]
			public required string Email { get; set; }

			[Required]
			public required string Adresse { get; set; }

			[Required]
			[DataType(DataType.Password)]
			public required string Password { get; set; }




			/*   public void OnGet()
			   {
			   }*/
	}
}

