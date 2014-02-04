namespace System.Web.Http
{
    using Shield.WebApi;

    public static class SharedKeyAuthenticationExtensions
    {
        public static HttpConfiguration UseSharedKeyAuthentication(this HttpConfiguration config, SharedKeyAuthenticationOptions options)
        {
            config.MessageHandlers.Add(new SharedKeyAuthenticationHandler(options));
            return config;
        }
    }
}
