using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Shield
{
    /// <summary>
    /// Validates HTTP Requests using a preshared key
    /// </summary>
    public class PresharedKeyAuthorizer : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            //var claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.Name, "superstar"));
            
            //var identity = new ClaimsIdentity(claims, "PresharedKey");
            //var principal = new ClaimsPrincipal(identity);
            
            //Thread.CurrentPrincipal = principal;
            //if (HttpContext.Current != null)
            //    HttpContext.Current.User = principal;

            var principal = new System.Security.Principal.GenericPrincipal(new System.Security.Principal.GenericIdentity("superstar", "PresharedKey"), null);
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
                HttpContext.Current.User = principal;

            return base.SendAsync(request, cancellationToken);
        }
    }
}
