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

        public static void SetSharedKey(this HttpClient client, string sharedKey)
        {
            client.DefaultRequestHeaders.Authorization = new SharedKeyAuthenticationHeaderValue(sharedKey);
        }
    }
}