using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebAppSample.Models;

namespace WebAppSample.Controllers
{
    public class InstitutionsController : Controller
    {
        private ApplicationDbContext _context;

        public InstitutionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Institutions
        public IActionResult Index()
        {
            var applicationDbContext = _context.Institution.Include(i => i.Applicant);
            return View(applicationDbContext.ToList());
        }

        // GET: Institutions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Institution institution = _context.Institution.Single(m => m.InstitutionID == id);
            if (institution == null)
            {
                return HttpNotFound();
            }

            return View(institution);
        }

        // GET: Institutions/Create
        public IActionResult Create()
        {
            ViewData["ApplicantID"] = new SelectList(_context.Set<Applicant>(), "ApplicantID", "Applicant");
            return View();
        }

        // POST: Institutions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Institution institution)
        {
            if (ModelState.IsValid)
            {
                _context.Institution.Add(institution);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ApplicantID"] = new SelectList(_context.Set<Applicant>(), "ApplicantID", "Applicant", institution.ApplicantID);
            return View(institution);
        }

        // GET: Institutions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Institution institution = _context.Institution.Single(m => m.InstitutionID == id);
            if (institution == null)
            {
                return HttpNotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Set<Applicant>(), "ApplicantID", "Applicant", institution.ApplicantID);
            return View(institution);
        }

        // POST: Institutions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Institution institution)
        {
            if (ModelState.IsValid)
            {
                _context.Update(institution);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ApplicantID"] = new SelectList(_context.Set<Applicant>(), "ApplicantID", "Applicant", institution.ApplicantID);
            return View(institution);
        }

        // GET: Institutions/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Institution institution = _context.Institution.Single(m => m.InstitutionID == id);
            if (institution == null)
            {
                return HttpNotFound();
            }

            return View(institution);
        }

        // POST: Institutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Institution institution = _context.Institution.Single(m => m.InstitutionID == id);
            _context.Institution.Remove(institution);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
