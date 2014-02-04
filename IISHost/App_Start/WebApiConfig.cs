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

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.UseBasicAuthentication(new Shield.WebApi.BasicAuthenticationOptions(ValidateUser));
            config.UseSharedKeyAuthentication(new Shield.WebApi.SharedKeyAuthenticationOptions(ValidateKey));
        }

        private static Task<IEnumerable<Claim>> ValidateUser(string id, string secret)
        {
            if (id == secret)
                return Task.FromResult<IEnumerable<Claim>>(CreateFakeClaims());

            return Task.FromResult<IEnumerable<Claim>>(null);
        }

        private static Task<IEnumerable<Claim>> ValidateKey(string key)
        {
            if (key == "123456789")
                return Task.FromResult<IEnumerable<Claim>>(CreateFakeClaims());

            return null;
        }

        private static IEnumerable<Claim> CreateFakeClaims()
        {
            return new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, "Id"),
                    new Claim(ClaimTypes.Name, "Bob"),
                    new Claim(ClaimTypes.Role, "Administrator")
                };
        }
    }
}
