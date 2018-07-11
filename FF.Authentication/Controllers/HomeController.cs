using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using FF.Authentication.Helper;
using Thinktecture.IdentityModel.Mvc;

namespace FF.Authentication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Auth(Roles = "Geek")]
        public ActionResult About()
        {
            return View((User as ClaimsPrincipal).Claims);
        }

        [ResourceAuthorize("Read", "ContactDetails")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ResourceAuthorize("Write", "ContactDetails")]
        [HandleForbidden]
        public ActionResult UpdateContact()
        {
            //Alternative to attribute:
            //if (!HttpContext.CheckAccess("Write", "ContactDetails", "some more data"))
            //{
            //    // either 401 or 403 based on authentication state
            //    return this.AccessDenied();
            //}

            ViewBag.Message = "Update your contact details!";

            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}