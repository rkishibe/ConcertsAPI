using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcertsAPI.Controllers
{
    public class ConcertsController : Controller
    {
        // GET: ConcertsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConcertsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConcertsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConcertsController/Create
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

        // GET: ConcertsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConcertsController/Edit/5
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

        // GET: ConcertsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConcertsController/Delete/5
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
        }
    }
}
