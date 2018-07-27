using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customers()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Movies()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
