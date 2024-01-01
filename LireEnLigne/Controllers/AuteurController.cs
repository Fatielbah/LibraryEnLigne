using Microsoft.AspNetCore.Mvc;

namespace LireEnLigne.Controllers
{
	public class AuteurController : Controller
	{
		public IActionResult AuteursIndex()
		{
			return View();
		}
	}
}
