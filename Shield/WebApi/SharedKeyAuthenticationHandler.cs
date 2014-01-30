namespace Shield.WebApi
{
    using System;
    using System.Linq;
    using System.Net.Http;

    public class SharedKeyAuthenticationHandler : AuthenticationHandler
    {
        public SharedKeyAuthenticationHandler(Func<string, bool> credentialValidationFunction)
        {
            this.credentialValidationFunction = credentialValidationFunction;
        }

        protected override bool CheckAccess(HttpRequestMessage request)
        {
            var authHeader = request.Headers.Authorization;
            if (authHeader.Scheme != "SharedKey")
                return false;

            return credentialValidationFunction(authHeader.Parameter);
        }

        private Func<string, bool> credentialValidationFunction;
    }
}