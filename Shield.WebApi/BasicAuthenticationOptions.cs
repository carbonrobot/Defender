namespace Shield.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class BasicAuthenticationOptions : AuthenticationOptions
    {
        public BasicAuthenticationOptions(Func<string, string, Task<IEnumerable<Claim>>> keyValidator)
            : base(AuthenticationTypes.Basic)
        {
            this.KeyValidator = keyValidator;
        }

        public Func<string, string, Task<IEnumerable<Claim>>> KeyValidator;
    }
}
