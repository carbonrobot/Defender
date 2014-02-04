namespace ConsoleHost
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // load a type in the webapi assembly so the controllers get loaded up
            var c = typeof(WebApi.FilesController);

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "Default", 
                "{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            appBuilder.UseBasicAuthentication(
                new Shield.Owin.BasicAuthenticationOptions(
                    AuthenticationManager.ValidateUser));
            
            appBuilder.UseSharedKeyAuthentication(
                new Shield.Owin.SharedKeyAuthenticationOptions(
                    AuthenticationManager.ValidateKey));

            appBuilder.UseWebApi(config);
        }
    }
}
