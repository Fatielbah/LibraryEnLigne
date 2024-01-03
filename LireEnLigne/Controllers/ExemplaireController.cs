using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LireEnLigne.Controllers
{
	public class ExemplaireController : Controller
	{
		private LibraryContext _context;

		public ExemplaireController(LibraryContext context)
		{
			_context = context;
		}
		// GET: ExemplaireController
		public ActionResult Index()
		{
			return View();
		}

		/*// GET: ExemplaireController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ExemplaireController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ExemplaireController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ExemplaireController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ExemplaireController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ExemplaireController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ExemplaireController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}*/

		//Get all Exemlaire with status dispo
		
		public IActionResult GetAllByStatus(string status)
		{

			//à developper
			return View();
		}


		//Trouver tous les exemplaires d'un livre by livreId

		public async Task<IActionResult> GetExemplairesByLivreId(int? livreId)
		{
			if(livreId == null || _context.Exemplaires == null) {
				return NotFound();

			}

			var exemplaires =await _context.Exemplaires.Where(e => e.LivreID == livreId).ToListAsync();

			if (exemplaires.Any())
			{

				//exemplaires contient tous les exemplaires du livre spécifié
				//à developper
				return View();// retourner tous les exemplaires 

			}
			else
			{
				//Lorsque aucun exemplaire n'a été trouvé pour ce livre
				return NotFound();
			}
		}
		

	}
}
