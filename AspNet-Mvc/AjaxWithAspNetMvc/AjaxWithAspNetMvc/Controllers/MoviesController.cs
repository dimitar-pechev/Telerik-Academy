using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AjaxWithAspNetMvc.Data;
using AjaxWithAspNetMvc.Models;

namespace AjaxWithAspNetMvc.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesDbContext db = new MoviesDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            var data = db.Movies.ToList();

            return View(data);
        }

        [HttpPost]
        public ActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return PartialView("_MoviesResult", this.db.Movies.ToList());
            }

            var data = db.Movies
                .Where(m => m.Title.ToLower().Contains(query.ToLower()))
                .ToList();

            return PartialView("_MoviesResult", data);
        }

        // GET: Movies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        
        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Director,Year,LeadingMaleRole,LeadingFemaleRole,Studio,StudioAddress")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.Id = Guid.NewGuid();
                this.db.Movies.Add(movie);
                this.db.SaveChanges();

                var data = this.db.Movies.ToList();

                return PartialView("_MoviesResult", data);
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Director,Year,LeadingMaleRole,LeadingFemaleRole,Studio,StudioAddress")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var movie = this.db.Movies.Find(id);
            this.db.Movies.Remove(movie);
            this.db.SaveChanges();

            var data = this.db.Movies.ToList();

            return PartialView("_MoviesResult", data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
