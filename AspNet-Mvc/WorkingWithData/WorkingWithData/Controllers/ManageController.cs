using System.Linq;
using System.Web.Mvc;
using WorkingWithData.Models;

namespace WorkingWithData.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var tweets = this.context.Tweets
                .Where(x => x.User.UserName == this.User.Identity.Name)
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return View(tweets);
        }
    }
}