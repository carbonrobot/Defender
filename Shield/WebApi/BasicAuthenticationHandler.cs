namespace Shield.WebApi
{
    using System;
    using System.Linq;
    using System.Net.Http;

    public class BasicAuthenticationHandler : AuthenticationHandler
    {
        public BasicAuthenticationHandler(Func<string, string, bool> credentialValidationFunction)
        {
            this.credentialValidationFunction = credentialValidationFunction;
        }

        protected override bool CheckAccess(HttpRequestMessage request)
        {
            var authHeader = request.Headers.Authorization;
            if (authHeader.Scheme != "Basic")
                return false;

            var auth = new BasicAuthenticationHeaderValue(authHeader.Parameter);
            return credentialValidationFunction(auth.UserName, auth.Password);
        }

        private Func<string, string, bool> credentialValidationFunction;
    }
}