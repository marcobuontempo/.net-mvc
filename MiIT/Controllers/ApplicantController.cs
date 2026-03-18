using Microsoft.AspNetCore.Mvc;
using MiIT.Models;

namespace MiIT.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly ApplicantDataContext _db;


        public ApplicantController(ApplicantDataContext db)
        {
            _db = db;
        }

        // GET: INDEX
        public IActionResult Index()
        {
            List<Applicant> applicants = _db.Applicant.OrderBy(a => -a.Gpa).ToList();
            return View(applicants);
        }

        // GET: ADD
        [HttpGet]
        public IActionResult Add()
        {
            Applicant applicant = new();
            return View(applicant);
        }

        // POST: ADD
        [HttpPost]
        public IActionResult Add(Applicant applicant)
        {
            if (!ModelState.IsValid) return View(applicant);

            _db.Applicant.Add(applicant);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: EDIT
        [HttpGet]
        public IActionResult Edit(long id)
        {
            Applicant applicant = _db.Applicant.Find(id);
            return View(applicant);
        }

        // POST: EDIT
        [HttpPost]
        public IActionResult Edit(Applicant applicant)
        {
            if (!ModelState.IsValid) return View(applicant);

            _db.Applicant.Update(applicant);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(long id)
        {
            Applicant applicant = _db.Applicant.Find(id);
            _db.Applicant.Remove(applicant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
