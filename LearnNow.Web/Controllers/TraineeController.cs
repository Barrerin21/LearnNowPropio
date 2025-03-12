using LearnNow.Class.Models;
using LearnNow.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnNow.Web.Controllers
{
    public class TraineeController : Controller
    {
        private readonly IRepositoryGeneric<TraineeModel> cr;

        public TraineeController(IRepositoryGeneric<TraineeModel> cr)
        {
            this.cr = cr;
        }

        // GET: TraineeController
        public async Task<ActionResult> Index()
        {
            var trainees = await cr.GetAll();
            return View(trainees);
        }

        // GET: TraineeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TraineeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TraineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TraineeModel trainee)
        {
            var id = await cr.Create(trainee);
            return RedirectToAction(nameof(Index));
        }


        // GET: TraineeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var trainee = await cr.GetById(id);
            return View(trainee);
        }

        // POST: TraineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TraineeModel trainee)
        {
            cr.Update(trainee);
            return RedirectToAction("Index");
        }

        // GET: TraineeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var trainee = await cr.GetById(id);
            return View(trainee);
        }

        // POST: TraineeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(TraineeModel trainee)
        {
            await cr.Delete(trainee.Id);
            return RedirectToAction("Index");
        }
    }
}
