using AspNetCore;
using LearnNow.Class;
using LearnNow.Class.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearnNow.Web.Controllers
{
    public class TrainingEventController : Controller
    {
        private readonly TrainingEventRepository trainingEventRepo;
        private readonly IRepositoryGeneric<CourseModel> courseRG;
        private readonly IRepositoryGeneric<LocationModel> locationRG;
        private readonly IRepositoryGeneric<TeacherModel> teacherRG;

        public TrainingEventController(
            TrainingEventRepository ter,
            IRepositoryGeneric<CourseModel> c,
            IRepositoryGeneric<LocationModel> l,
            IRepositoryGeneric<TeacherModel> t
            )
        {
            trainingEventRepo = ter;
            courseRG = c;
            locationRG = l;
            teacherRG = t;
        }

        // GET: TrainingEventController
        public async Task<ActionResult> Index()
        {
            var lstTE = await trainingEventRepo.GetAll();
            return View(lstTE.AsEnumerable());
        }

        // GET: TrainingEventController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrainingEventController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Courses = new SelectList(await courseRG.GetAll(), "Id", "Title");
            ViewBag.Locations = new SelectList(await locationRG.GetAll(), "Id", "Name");
            ViewBag.Teachers = new SelectList(await teacherRG.GetAll(), "Id", "Name");
            var model = new TrainingEventModel
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };

            return View(model);
        }

        // POST: TrainingEventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection formCollection)
        {
            var te = new TrainingEventModel();
            try
            {
                te.CourseId = int.Parse(formCollection["CourseId"]!);
                te.LocationId = int.Parse(formCollection["LocationId"]!);
                te.TeacherId = int.Parse(formCollection["TeacherId"]!);
                te.StartDate = DateTime.Parse(formCollection["StartDate"]!);
                te.EndDate = DateTime.Parse(formCollection["EndtDate"]!);

                await trainingEventRepo.Create(te);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Courses = new SelectList(await courseRG.GetAll(), "Id", "Title");
                ViewBag.Locations = new SelectList(await locationRG.GetAll(), "Id", "Name");
                ViewBag.Teachers = new SelectList(await teacherRG.GetAll(), "Id", "Name");

                ModelState.AddModelError(string.Empty, ex.Message);

                return View(te);
            }
        }

        // GET: TrainingEventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrainingEventController/Edit/5
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

        // GET: TrainingEventController/Delete/5
        public async Task<ActionResult> Delete(int id)   
        {
            var te = await trainingEventRepo.GetById(id);
            return View();
        }

        // POST: TrainingEventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(TrainingEventModel trainingEvent)
        {
            await trainingEventRepo.Delete(trainingEvent.Id);
            return RedirectToAction("Index");
        }
    }
}
