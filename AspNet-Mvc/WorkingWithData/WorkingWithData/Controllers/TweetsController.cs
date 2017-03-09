using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Web.Mvc;
using WorkingWithData.Models;
using WorkingWithData.Services.Contracts;

namespace WorkingWithData.Controllers
{
    [Authorize(Roles = "admin")]
    public class TweetsController : Controller
    {
        private ITweetService service;

        public TweetsController(ITweetService service)
        {
            this.service = service;
        }
        
        public ActionResult Index()
        {
            var tweets = this.service.GetAllTweets();
            return View(tweets);
        }
        
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tweet = this.service.GetById(id);

            if (tweet == null)
            {
                return HttpNotFound();
            }

            return View(tweet);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,CreatedOn,UserId")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                this.service.Create(userId, tweet);
                
                return RedirectToAction("Index");
            }
            
            return View(tweet);
        }
        
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tweet = this.service.GetById(id);

            if (tweet == null)
            {
                return HttpNotFound();
            }
            
            return View(tweet);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,CreatedOn,UserId")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                this.service.Edit(tweet);
                return RedirectToAction("Index");
            }

            return View(tweet);
        }
        
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tweet = this.service.GetById(id);

            if (tweet == null)
            {
                return HttpNotFound();
            }

            return View(tweet);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this.service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
