namespace Shield.Owin
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Infrastructure;

    public class SharedKeyAuthenticationHandler : AuthenticationHandler<SharedKeyAuthenticationOptions>
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
                    Response.Headers.AppendValues("WWW-Authenticate", AuthenticationTypes.SharedKey);
                }
            }

            return Task.FromResult<object>(null);
        }

        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            var authzType = AuthenticationTypes.SharedKey + " ";
            var authzValue = Request.Headers.Get("Authorization");
            if (string.IsNullOrEmpty(authzValue) || !authzValue.StartsWith(authzType, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var key = authzValue.Substring(authzType.Length).Trim();
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