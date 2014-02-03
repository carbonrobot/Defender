namespace WebApi
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Owin;
    using Shield.WebApi;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            //// authentication
            //config.MessageHandlers.Add(new BasicAuthenticationHandler((usr, pwd) =>
            //{
            //    return usr == pwd;
            //}));

            // routing
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // middleware
            //appBuilder.UseBasicAuthentication(new Thinktecture.IdentityModel.Owin.BasicAuthenticationOptions("Basic", ValidateUser));

            appBuilder.UseSharedKeyAuthentication(new SharedKeyAuthenticationOptions("123456789"));

            appBuilder.UseWebApi(config);
        }

        private Task<IEnumerable<Claim>> ValidateUser(string id, string secret)
        {
            if (id == secret)
            {
                var claims = new List<Claim>(){
                    new Claim(ClaimTypes.NameIdentifier, id),
                    new Claim(ClaimTypes.Name, "Bob"),
                    new Claim(ClaimTypes.Role, "Administrator")
                };
                return Task.FromResult<IEnumerable<Claim>>(claims);
            }

            return Task.FromResult<IEnumerable<Claim>>(null);
        }
    }
}
