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
        [HttpGet]
        public async Task<IActionResult> LivreIndex(Genre? genre, string searchTerm)
        {
            List<Livre> livres;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // If a search term is provided, filter the results
                livres = await _context.Livres
                    .Where(l => EF.Functions.Like(l.Titre, $"%{searchTerm}%"))
                    .ToListAsync();
            }
            else if (genre.HasValue)
            {
                // Fetch the books based on the selected genre
                livres = await _context.Livres.Where(l => l.Genre == genre).ToListAsync();
            }
            else
            {
                // Retrieve all Livres
                livres = await _context.Livres.ToListAsync();
            }
            if (livres.Count == 0)
            {
                ViewData["NoBooksMessage"] = "Aucun livre trouvé.";
            }

            return View(livres);
        }

        /*public IActionResult LivreIndex(Genre? genre)
        {
            List<Livre> livres;

            if (genre.HasValue)
            {
                // Fetch the books based on the selected genre
                livres = _context.Livres.Where(l => l.Genre == genre).ToList();
            }
            else
            {
                // récupérer tous les Livres
                livres = _context.Livres.ToList();
            }

            return View("LivreIndex", livres);
        }*/

        //search for books by a partial name match.
        [HttpGet]
		public async Task<IActionResult> GetLivreByNameLike(string nameLike)
		{

			if(nameLike == null)
			{
				return NotFound();
			}
			var LivresByNameLike = await _context.Livres.Where(l => EF.Functions.Like(l.Titre, $"%{nameLike}%")).ToListAsync();
			return View();//retourner la liste des livres
	
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
