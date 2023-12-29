using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LireEnLigne.Data;

namespace LireEnLigne.Controllers
{
	public class UserController : Controller
	{
		private readonly LibraryContext _context;
		public UserController(LibraryContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		
	}
}
