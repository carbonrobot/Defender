namespace Owin
{
    using System;
    using Shield.Owin;

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
