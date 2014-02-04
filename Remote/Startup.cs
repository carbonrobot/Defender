namespace WebApi
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.UseBasicAuthentication(new Shield.WebApi.BasicAuthenticationOptions(ValidateUser));

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
         
            return null;
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
