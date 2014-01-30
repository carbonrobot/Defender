namespace System.Net.Http
{
    using System.Net.Http;
    using System.Net.Http.Headers;

	public static class HttpClientExtensions
    {
        public static void SetBasicAuthentication(this HttpClient client, string userName, string password)
        {
            client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(userName, password);
        }

        public static void SetSharedKey(this HttpClient client, string token)
        {
            client.SetToken("SharedKey", token);
        }

        public static void SetToken(this HttpClient client, string scheme, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);
        }
    }
}