using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using WorkingWithData.Models;

namespace WorkingWithData.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.Tweets = this.context.Tweets.OrderByDescending(x => x.CreatedOn).ToList();
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Content,CreatedOn,UserId")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                tweet.Id = Guid.NewGuid();
                tweet.UserId = this.User.Identity.GetUserId();
                tweet.User = this.context.Users.Find(tweet.UserId);

                this.context.Tweets.Add(tweet);
                this.context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(this.context.Users, "Id", "Email", tweet.UserId);
            return View(tweet);
        }

        public ActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                ViewBag.Tweets = this.context.Tweets.OrderByDescending(x => x.CreatedOn).ToList();

                return View("Index");
            }

            ViewBag.Tweets = this.context.Tweets
                .Where(x => x.Content.ToLower().Contains(query.ToLower()))
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return View("Index");
        }
    }
}