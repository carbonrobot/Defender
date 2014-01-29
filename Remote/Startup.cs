namespace WebApi
{
    using System;
    using System.Web.Http;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            // TODO: SSL Handler

            // authentication
            config.MessageHandlers.Add(new Shield.AuthenticationHandler());

            // routing
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
