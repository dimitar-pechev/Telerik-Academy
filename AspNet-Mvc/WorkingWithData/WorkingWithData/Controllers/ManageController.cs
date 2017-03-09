using System.Web.Mvc;
using WorkingWithData.Services.Contracts;

namespace WorkingWithData.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ITweetService service;

        public ManageController(ITweetService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var username = this.User.Identity.Name;

            var tweets = this.service.GetTweetsByUser(username);

            return View(tweets);
        }
    }
}