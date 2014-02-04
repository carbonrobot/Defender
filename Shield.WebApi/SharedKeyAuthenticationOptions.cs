namespace Shield.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class SharedKeyAuthenticationOptions : AuthenticationOptions
    {
        public SharedKeyAuthenticationOptions(Func<string, Task<IEnumerable<Claim>>> keyValidator)
            : base(Shield.AuthenticationTypes.SharedKey)
        {
            this.KeyValidator = keyValidator;
        }

        public Func<string, Task<IEnumerable<Claim>>> KeyValidator;
    }
}