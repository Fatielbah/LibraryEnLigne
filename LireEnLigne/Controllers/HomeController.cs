﻿using LireEnLigne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace LireEnLigne.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly LibraryContext _context;
        public HomeController(LibraryContext context)
        {
            _context = context;
        }
        /*public HomeController(ILogger<HomeController> logger)
		{
            _logger = logger;
			//var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value


		}*/
		public IActionResult Index()
        {
            return View();
        }

        public IActionResult CatLivres(Genre genre)
        {
            // Fetch the books based on the selected genre
            var livres = _context.Livres.Where(l => l.Genre == genre).ToList();

            
            return View(livres);
        }

        public IActionResult CatLivresAuteur(int AuteurID)
        {
            // Fetch the books based on the selected genre
            var livres = _context.Livres.Where(l => l.AuteurID == AuteurID).ToList();

            return View(livres);
        }
        
        public IActionResult Privacy()
		{
			return View();
		}
		
		

        public IActionResult Aproposdecelivre(int id)
        {
            // Fetch the Livre and its associated Exemplaire based on the provided LivreID
            var livreWithExemplaire = _context.Livres
                .Where(l => l.LivreID == id)
                .Include(l => l.Exemplaires) // Assuming there's a navigation property from Livre to Exemplaire
                .FirstOrDefault();

            if (livreWithExemplaire != null)
            {
                // Pass the Livre and its associated Exemplaire to the view
                return View(livreWithExemplaire);
            }
            else
            {
                // Handle the case where LivreID is not found
                return NotFound();
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}