using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using WorkingWithData.Models;
using WorkingWithData.Services.Contracts;

namespace WorkingWithData.Controllers
{
    public class HomeController : Controller
    {
        private ITweetService service;

        public HomeController(ITweetService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Tweets = this.service.GetAllTweets();
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Content,CreatedOn,UserId")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                this.service.Create(userId, tweet);
                
                return RedirectToAction("Index");
            }
            
            return View(tweet);
        }

        public ActionResult Search(string query)
        {
            ViewBag.Tweets = this.service.GetTweetsByQuery(query);

            return View("Index");
        }
    }
}