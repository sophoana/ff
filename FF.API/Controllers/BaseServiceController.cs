using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;

namespace FF.API.Controllers
{
    public class BaseServiceController : ApiController
    {
        private BasicAuthenticationHeaderValue _basicAuthenticationHeaderValue;
        private IIdentity _userIdentity;

        public BaseServiceController(
            BasicAuthenticationHeaderValue basicAuthenticationHeaderValue,
           IIdentity userIdentity)
        {
            _basicAuthenticationHeaderValue = basicAuthenticationHeaderValue;
            _userIdentity = userIdentity;
        }

    }
}
