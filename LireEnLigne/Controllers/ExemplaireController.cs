using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LireEnLigne.Controllers
{
	public class ExemplaireController : Controller
	{
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
	}
}
