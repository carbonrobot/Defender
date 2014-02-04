namespace Shield.Owin
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.Owin.Security;

    public class BasicAuthenticationOptions : AuthenticationOptions
    {
        public Func<string, string, Task<IEnumerable<Claim>>> KeyValidator;

        public BasicAuthenticationOptions()
            : base("Basic")
        {
        }

        public BasicAuthenticationOptions(Func<string, string, Task<IEnumerable<Claim>>> validateKey)
            : base("Basic")
        {
            this.KeyValidator = validateKey;
        }
    }
}