namespace Shield.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        public BasicAuthenticationHandler(BasicAuthenticationOptions options)
            : base(options)
        {
        }

        protected override async Task<IEnumerable<Claim>> AuthenticateCoreAsync(HttpRequestMessage request)
        {
            var authHeader = request.Headers.Authorization;
            if (authHeader.Scheme != Options.AuthenticationType)
                return null;

            var auth = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');

            return await Options.KeyValidator(auth[0], auth[1]);
        }
    }
}