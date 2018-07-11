using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FF.API.Controllers
{
    [RoutePrefix("test")]
    [Authorize]
    public class TestController : ApiController
    {
        /// <summary>
        /// Requires login, returns {"One","Two"}
        /// </summary>
        /// <returns></returns>
        [Route]
        [HttpGet]
        [ResponseType(typeof(String[]))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new[]
            {
                "One",
                "Two"
        });
        }

        /// <summary>
        /// Returns "Pong"
        /// </summary>
        /// <returns>Pong</returns>
        [Route("ping")]
        [HttpGet]
        [AllowAnonymous]
        [ResponseType(typeof(String))]
         public HttpResponseMessage Ping()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Pong");
        }

    }
}
