using FF.Contracts.Service;
using System.Net.Http;
using System.Security.Principal;

namespace FF.API.Controllers
{
    public class FruitFinderController : BaseServiceController, IFruitFinderService
    {
        public FruitFinderController(BasicAuthenticationHeaderValue basicAuthenticationHeaderValue, IIdentity userIdentity) 
            : base(basicAuthenticationHeaderValue, userIdentity)
        {
        }

    }
}
