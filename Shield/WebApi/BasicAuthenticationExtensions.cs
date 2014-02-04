namespace System.Web.Http
{
    using Shield.WebApi;

    public static class BasicAuthenticationExtensions
    {
        public static HttpConfiguration UseBasicAuthentication(this HttpConfiguration config, BasicAuthenticationOptions options)
        {
            config.MessageHandlers.Add(new BasicAuthenticationHandler(options));
            return config;
        }
    }
}
