using Microsoft.AspNetCore.Mvc;

namespace LireEnLigne.Controllers
{
	public class AuteurController : Controller
	{
		public IActionResult AuteursIndex()
		{
			return View();
		}

		[HttpGet("/AllAuteurs")]
		public void GetAllAuteurs()
		{

		}

		[HttpGet]
		public void GetAuteurByName(string name)
		{

		}

		

		
	}
}
