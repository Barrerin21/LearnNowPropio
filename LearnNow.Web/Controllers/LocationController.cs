using LearnNow.Class.Models;
using LearnNow.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnNow.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly IRepositoryGeneric<LocationModel> cr;

        public LocationController(IRepositoryGeneric<LocationModel> cr)
        {
            this.cr = cr;
        }

        // GET: LocationController
        public async Task<ActionResult> Index()
        {
            var locations = await cr.GetAll();
            return View(locations);
        }

        // GET: LocationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LocationModel location)
        {
            var id = await cr.Create(location);
            return RedirectToAction(nameof(Index));
        }


        // GET: LocationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var location = await cr.GetById(id);
            return View(location);
        }

        // POST: LocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocationModel location)
        {
            cr.Update(location);
            return RedirectToAction("Index");
        }

        // GET: LocationController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var location = await cr.GetById(id);
            return View(location);
        }

        // POST: LocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(LocationModel course)
        {
            await cr.Delete(course.Id);
            return RedirectToAction("Index");
        }
    }
}
