using Microsoft.AspNetCore.Mvc;

namespace LireEnLigne.Controllers
{
	public class LivreController : Controller
	{

		
		public IActionResult LivreIndex()
		{
			return View();
		}
	}
}
