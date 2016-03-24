using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebAppSample.Models;

namespace WebAppSample.Controllers
{
    public class ApplicantsController : Controller
    {
        private ApplicationDbContext _context;

        public ApplicantsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Applicants
        public IActionResult Index()
        {
            return View(_context.Applicant.ToList());
        }

        // GET: Applicants/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Applicant applicant = _context.Applicant.Single(m => m.ApplicantID == id);
            if (applicant == null)
            {
                return HttpNotFound();
            }

            return View(applicant);
        }

        // GET: Applicants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                _context.Applicant.Add(applicant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Applicant applicant = _context.Applicant.Single(m => m.ApplicantID == id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                _context.Update(applicant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Applicant applicant = _context.Applicant.Single(m => m.ApplicantID == id);
            if (applicant == null)
            {
                return HttpNotFound();
            }

            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = _context.Applicant.Single(m => m.ApplicantID == id);
            _context.Applicant.Remove(applicant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
