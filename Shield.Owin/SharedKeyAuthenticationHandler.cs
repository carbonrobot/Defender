namespace Shield.Owin
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.Owin.Security;

    public class SharedKeyAuthenticationHandler : Microsoft.Owin.Security.Infrastructure.AuthenticationHandler<SharedKeyAuthenticationOptions>
    {
        public SharedKeyAuthenticationHandler(SharedKeyAuthenticationOptions options)
        {
        }

        protected override Task ApplyResponseChallengeAsync()
        {
            if (Response.StatusCode == 401)
            {
                var challenge = Helper.LookupChallenge(Options.AuthenticationType, Options.AuthenticationMode);
                if (challenge != null)
                {
                    Response.Headers.AppendValues("WWW-Authenticate", "SharedKey");
                }
            }

            return Task.FromResult<object>(null);
        }

        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            var authzValue = Request.Headers.Get("Authorization");
            if (string.IsNullOrEmpty(authzValue) || !authzValue.StartsWith("SharedKey ", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var key = authzValue.Substring("SharedKey ".Length).Trim();
            var claims = await Options.KeyValidator(key);
            if (claims != null)
            {
                var id = new ClaimsIdentity(claims, Options.AuthenticationType);
                return new AuthenticationTicket(id, new AuthenticationProperties());
            }

            return null;
        }
    }
}