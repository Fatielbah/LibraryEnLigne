using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace LireEnLigne.Controllers
{
	public class LivreController : Controller
	{
		private LibraryContext _context;
		public LivreController(LibraryContext context)
		{
			_context = context;
		}

		public IActionResult LivreIndex()
		{
			return View();
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

		//Get : Avoir la liste des livres by auteur

		public async Task<IActionResult> GetAllLivreByAuteur(int auteurId)
		{
			var AllLivres = await _context.Livres.Where(l => l.AuteurID == auteurId).ToListAsync();
			if(AllLivres != null)
			{
				//Acceder aux livres associés à l'auteur avec l id auteurId
				//var livres = AllLivres.ToList();
				return View(); // retourner la liste des livre pour l'auteur qui a l'id auteurId

			}
			else
			{
				//auteur not found
				return NotFound();
			}
		}

		public async Task<IActionResult> GetLivresByLettre(char lettre)
		{
			var livresByLetter = await _context.Livres.Where(l => l.Titre.StartsWith(lettre)).ToListAsync();

			if(livresByLetter != null)
			{
				return View(livresByLetter);
			}
			else
			{
				return NotFound();
			}
		}

		//find all books that begin contains a word

		public async Task<IActionResult> GetLivresByMot(string mot)
		{
			var livresByMot = await _context.Livres.Where(l => l.Titre.Contains(mot)).ToListAsync();
			
			if(livresByMot != null)
			{
				return View();// retourner la liste des livres qui contiennent  mot dans le titre
			}
			else
			{
				return NotFound();
			}
		}




	}
}
