namespace System.Net.Http
{
    using System;
    using System.Net.Http.Headers;
    using System.Text;

	public class SharedKeyAuthenticationHeaderValue : AuthenticationHeaderValue
    {
        public SharedKeyAuthenticationHeaderValue(string sharedKey)
            : base("SharedKey", sharedKey){
        }
    }
}