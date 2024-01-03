using Microsoft.AspNetCore.Mvc;

namespace LireEnLigne.Controllers
{
	public class LivreController : Controller
	{

		
		public IActionResult LivreIndex()
		{
			return View();
		}

		[HttpGet]
		public void GetLivreByAuteur(Auteur auteur)
		{

		}

		[HttpGet]
		public void GetLivreByNameLike(string nameLike)
		{

		}

		[HttpGet]
		public void GetLivreStartWith(string startWith)
		{

		}

	/*	[HttpGet]
		public void GetLivre*/

		

	}
}
