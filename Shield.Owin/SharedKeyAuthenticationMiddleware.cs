namespace Shield.Owin
{
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Infrastructure;

    public class SharedKeyAuthenticationMiddleware : AuthenticationMiddleware<SharedKeyAuthenticationOptions>
    {
        public SharedKeyAuthenticationMiddleware(OwinMiddleware next, SharedKeyAuthenticationOptions options)
            : base(next, options)
        {

        }

        protected override AuthenticationHandler<SharedKeyAuthenticationOptions> CreateHandler()
        {
            return new SharedKeyAuthenticationHandler(Options);
        }
    }
}
