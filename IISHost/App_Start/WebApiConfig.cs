namespace IISHost
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // load a type in the webapi assembly so the controllers get loaded up
            var c = typeof(WebApi.FilesController);

            config.Routes.MapHttpRoute(
                name: "DefaultRoutes",
                routeTemplate: "{controller}/{id}",
                defaults: null,
                constraints: new { id = @"\d+" }
            );

            config.Routes.MapHttpRoute(
                name: "ActionRoutes",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional }
            );

            config.UseBasicAuthentication(new Shield.WebApi.BasicAuthenticationOptions(AuthenticationManager.ValidateUser));
            config.UseSharedKeyAuthentication(new Shield.WebApi.SharedKeyAuthenticationOptions(AuthenticationManager.ValidateKey));
        }
        
    }
}
