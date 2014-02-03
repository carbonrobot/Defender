using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;

namespace Shield.WebApi
{
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
