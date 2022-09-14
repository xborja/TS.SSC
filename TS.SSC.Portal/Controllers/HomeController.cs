using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;

namespace TS.SSC.Portal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["GlbUsrInst2774378"] == null)
            {
                HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AnotherLink()
        {
            return View("Index");
        }
    }
}
