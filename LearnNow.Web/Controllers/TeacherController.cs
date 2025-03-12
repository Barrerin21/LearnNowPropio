using LearnNow.Class.Models;
using LearnNow.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnNow.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IRepositoryGeneric<TeacherModel> cr;

        public TeacherController(IRepositoryGeneric<TeacherModel> cr)
        {
            this.cr = cr;
        }

        // GET: TeacherController
        public async Task<ActionResult> Index()
        {
            var teachers = await cr.GetAll();
            return View(teachers);
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeacherModel teacher)
        {
            var id = await cr.Create(teacher);
            return RedirectToAction(nameof(Index));
        }


        // GET: TeacherController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var teacher = await cr.GetById(id);
            return View(teacher);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherModel teacher)
        {
            cr.Update(teacher);
            return RedirectToAction("Index");
        }

        // GET: TeacherController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var teacher = await cr.GetById(id);
            return View(teacher);
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(TeacherModel teacher)
        {
            await cr.Delete(teacher.Id);
            return RedirectToAction("Index");
        }
}
}
