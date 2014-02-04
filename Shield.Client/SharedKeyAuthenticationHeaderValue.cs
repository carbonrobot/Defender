namespace System.Net.Http
{
    using System;
    using System.Net.Http.Headers;
    using System.Text;
    using Shield;

	public class SharedKeyAuthenticationHeaderValue : AuthenticationHeaderValue
    {
        public SharedKeyAuthenticationHeaderValue(string sharedKey)
            : base(AuthenticationTypes.SharedKey, sharedKey)
        {
        }
    }
}