namespace Owin
{
    using System;
    using Shield.Owin;

    public static class BasicAuthenticationExtensions
    {
        public static IAppBuilder UseBasicAuthentication(this IAppBuilder app, BasicAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException("app");

            return app.Use<BasicAuthenticationMiddleware>(options);
        }
    }
}
