using System.Web.Mvc;

namespace FF.Authentication.Helper
{
    /// <summary>
    /// Use this custom auth attribute instead of the standard Authorize attribute
    /// to avoid an endless loop when the user is authenticated but not in the correct
    /// role.
    /// </summary>
    public class AuthAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // 403 we know who you are, but you haven't been granted access
                filterContext.Result = new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
            }
            else
            {
                // 401 who are you? go login and then try again
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}