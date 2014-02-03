using System;
using Shield.WebApi;

namespace Owin
{
    public static class SharedKeyAuthenticationExtensions
    {
        public static IAppBuilder UseSharedKeyAuthentication(this IAppBuilder app, SharedKeyAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException("app");

            return app.Use<SharedKeyAuthenticationMiddleware>(options);
        }
    }
}
