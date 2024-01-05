using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using System.Net;
using System.Xml.Linq;

namespace LireEnLigne.Controllers
{
	public class AuteurController : Controller
	{

		private readonly LibraryContext _context;
		public AuteurController(LibraryContext context)
		{
			_context = context;
		}
		
		/*public IActionResult AuteursIndex()
		{
			return View();
		}*/

		public async Task<IActionResult> AuteursIndex()
		{

			//récupérer tous les auteurs 
			var allAuteurs =await _context.Auteurs.ToListAsync();
			if (allAuteurs.Any())
			{
				return View(allAuteurs); // retourner la liste des auteurs

			}
			else
			{
				// à developper
				//Aucun auteur trouvé dans la base de données
				return NotFound();
			}
			
		}

		//Get: get auteur by its name
		public async Task<IActionResult> GetAuteurByName(string? name)
		{
			if (name == null || _context == null)
			{
				return NotFound();

			}

			var auteurByName = await _context.Auteurs
						.FirstOrDefaultAsync(a => a.AuteurName == name);

			if (auteurByName != null)
			{
				return View(); //retournez l'auteur 
			}
			else
			{
				return NotFound();
			}


		}
	}

		

		
	}
