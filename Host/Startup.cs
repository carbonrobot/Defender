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

            appBuilder.UseBasicAuthentication(new Shield.Owin.BasicAuthenticationOptions(ValidateUser));
            appBuilder.UseSharedKeyAuthentication(new Shield.Owin.SharedKeyAuthenticationOptions(ValidateKey));

            appBuilder.UseWebApi(config);
        }

        private Task<IEnumerable<Claim>> ValidateUser(string id, string secret)
        {
            if (id == secret)
                return Task.FromResult<IEnumerable<Claim>>(CreateFakeClaims());

            return Task.FromResult<IEnumerable<Claim>>(null);
        }

        private Task<IEnumerable<Claim>> ValidateKey(string key)
        {
            if (key == "123456789")
                return Task.FromResult<IEnumerable<Claim>>(CreateFakeClaims());

            return Task.FromResult<IEnumerable<Claim>>(null);
        }

        private IEnumerable<Claim> CreateFakeClaims()
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
