namespace Shield.WebApi.Authorization
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] claims;

        public ClaimsAuthorizeAttribute(params string[] claims)
        {
            this.claims = claims;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var principal = (ClaimsPrincipal)actionContext.RequestContext.Principal;

            // must present all claims
            foreach (var value in claims)
                if (false == principal.HasClaim(ClaimTypes.Role, value)) return false;

            return true;
        }
    }
}