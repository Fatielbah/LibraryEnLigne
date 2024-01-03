using Microsoft.AspNetCore.Mvc;

namespace LireEnLigne.Controllers
{
	public class EmpruntController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
