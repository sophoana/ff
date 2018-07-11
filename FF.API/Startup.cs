using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(FF.API.Startup))]

namespace FF.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44395/identity",
                RequiredScopes = new[] { "sampleApi" }
            });

            // web api configuration
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.EnableSwagger("docs/{apiVersion}/swagger", c =>
            {
                c.SingleApiVersion("v1", "Super duper API");
                
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var fileName = Assembly
                    .GetExecutingAssembly()
                    .GetName()
                    .Name + ".XML";
                var commentsFile = Path.Combine(baseDirectory, "bin", fileName);
                c.IncludeXmlComments(commentsFile);
            })
            //.EnableSwaggerUi()
            ;
            

            app.UseWebApi(config);
        }
    }
}
