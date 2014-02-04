namespace Shield.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class SharedKeyAuthenticationHandler : AuthenticationHandler<SharedKeyAuthenticationOptions>
    {
        public SharedKeyAuthenticationHandler(SharedKeyAuthenticationOptions options)
            : base(options)
        {
        }

        protected override async Task<IEnumerable<Claim>> AuthenticateCoreAsync(HttpRequestMessage request)
        {
            var authHeader = request.Headers.Authorization;
            if (authHeader.Scheme != Options.AuthenticationType)
                return null;

            return await Options.KeyValidator(authHeader.Parameter);
        }
    }
}