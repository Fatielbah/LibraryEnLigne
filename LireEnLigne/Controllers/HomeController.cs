using LireEnLigne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace LireEnLigne.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(ILogger<HomeController> logger)
		{
            _logger = logger;
			//var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value


		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult CatLivres()
        {
            return View();
        }
		public IActionResult Privacy()
		{
			return View();
		}
		
		public IActionResult Aproposdecelivre()
        {
            return View();
        }
		
		
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}