using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace Shield.WebApi
{
    public class SharedKeyAuthenticationOptions : AuthenticationOptions
    {
        public string SharedKey { get; set; }

        public SharedKeyAuthenticationOptions()
            : base("SharedKey")
        {

        }

        public SharedKeyAuthenticationOptions(string sharedKey)
            : base("SharedKey")
        {
            this.SharedKey = sharedKey;
        }

    }
}
