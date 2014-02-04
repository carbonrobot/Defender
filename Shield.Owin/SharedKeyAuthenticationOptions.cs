namespace Shield.Owin
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Owin.Security;

    using System.Security.Claims;

    public class SharedKeyAuthenticationOptions : AuthenticationOptions
    {
        public Func<string, Task<IEnumerable<Claim>>> KeyValidator;

        public SharedKeyAuthenticationOptions()
            : base(AuthenticationTypes.SharedKey)
        {

        }

        public SharedKeyAuthenticationOptions(Func<string, Task<IEnumerable<Claim>>> validateKey)
            : base(AuthenticationTypes.SharedKey)
        {
            this.KeyValidator = validateKey;
        }
    }
}
