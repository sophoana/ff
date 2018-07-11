using System.Net.Http;
using System.Security.Principal;

namespace FF.API.Controllers
{
    public class FruitReviewController : BaseServiceController
    {
        public FruitReviewController(BasicAuthenticationHeaderValue basicAuthenticationHeaderValue, IIdentity userIdentity) : base(basicAuthenticationHeaderValue, userIdentity)
        {
        }


    }
}
