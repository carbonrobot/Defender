namespace System.Net.Http
{
    using System;
    using System.Net.Http.Headers;
    using System.Text;

	public class BasicAuthenticationHeaderValue : AuthenticationHeaderValue
    {
        public BasicAuthenticationHeaderValue(string userName, string password)
            : base("Basic", EncodeCredential(userName, password)){
                this.UserName = userName;
                this.Password = password;
        }

        public BasicAuthenticationHeaderValue(string credentials) : base("Basic")
        {
            var tokens = DecodeCredentials(credentials);
            this.UserName = tokens[0];
            this.Password = tokens[1];
        }

        private static string EncodeCredential(string userName, string password)
        {
            var encoding = Encoding.UTF8;
            var credential = String.Format("{0}:{1}", userName, password);

            return Convert.ToBase64String(encoding.GetBytes(credential));
        }

        private static string[] DecodeCredentials(string credentials)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(credentials)).Split(':');
        }

        public string Password { get; private set; }
        public string UserName { get; private set; }
    }
}