namespace Shield.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    /// <summary>
    /// Validates HTTP Requests using a preshared key
    /// </summary>
    public class AuthenticationHandler : DelegatingHandler
    {
        protected virtual bool CheckAccess(HttpRequestMessage request)
        {
            return false;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (CheckAccess(request))
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, "superstar"));

                var identity = new ClaimsIdentity(claims, "PresharedKey");
                var principal = new ClaimsPrincipal(identity);
                SetPrincipal(request, principal);
            }

            return base.SendAsync(request, cancellationToken);
        }

        private void SetPrincipal(HttpRequestMessage request, IPrincipal principal)
        {
            // for self hosting with OWIN
            request.GetRequestContext().Principal = principal;

            // for hosting with iis
            if (HttpContext.Current != null)
                HttpContext.Current.User = principal;

            // for all others
            Thread.CurrentPrincipal = principal;
        }
    }
}