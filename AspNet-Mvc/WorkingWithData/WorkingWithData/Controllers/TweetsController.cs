using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WorkingWithData.Models;

namespace WorkingWithData.Controllers
{
    [Authorize(Roles = "admin")]
    public class TweetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tweets
        public ActionResult Index()
        {
            var tweets = db.Tweets.Include(t => t.User);
            return View(tweets.ToList());
        }

        // GET: Tweets/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // GET: Tweets/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,CreatedOn,UserId")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                tweet.Id = Guid.NewGuid();
                tweet.UserId = this.User.Identity.GetUserId();
                tweet.User = this.db.Users.Find(tweet.UserId);

                db.Tweets.Add(tweet);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", tweet.UserId);
            return View(tweet);
        }

        // GET: Tweets/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", tweet.UserId);
            return View(tweet);
        }

        // POST: Tweets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,CreatedOn,UserId")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tweet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", tweet.UserId);
            return View(tweet);
        }

        // GET: Tweets/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // POST: Tweets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Tweet tweet = db.Tweets.Find(id);
            db.Tweets.Remove(tweet);
            db.SaveChanges();
            return RedirectToAction("Index");
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
