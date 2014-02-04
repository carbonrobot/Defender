namespace Shield.Owin
{
    using System;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Infrastructure;

    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        public BasicAuthenticationHandler(BasicAuthenticationOptions options)
        {
        }

        protected override Task ApplyResponseChallengeAsync()
        {
            if (Response.StatusCode == 401)
            {
                var challenge = Helper.LookupChallenge(Options.AuthenticationType, Options.AuthenticationMode);
                if (challenge != null)
                {
                    Response.Headers.AppendValues("WWW-Authenticate", AuthenticationTypes.Basic);
                }
            }

            return Task.FromResult<object>(null);
        }

        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            var authzType = AuthenticationTypes.Basic + " ";
            var authzValue = Request.Headers.Get("Authorization");
            if (string.IsNullOrEmpty(authzValue) || !authzValue.StartsWith(authzType, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var token = authzValue.Substring(authzType.Length).Trim();
            var userpass = Encoding.UTF8.GetString(Convert.FromBase64String(token)).Split(':');
            
            var claims = await Options.KeyValidator(userpass[0], userpass[1]);
            if (claims != null)
            {
                var id = new ClaimsIdentity(claims, Options.AuthenticationType);
                return new AuthenticationTicket(id, new AuthenticationProperties());
            }

            return null;
        }
    }
}