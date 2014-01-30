namespace Client
{
    using System;
    using System.Net.Http;

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Press [Enter] to begin the web api request");
            Console.ReadLine();
            
            var baseAddress = "http://localhost:9000/";

            Console.WriteLine("Using basic authentication");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.SetBasicAuthentication("banana", "banana");

                var response = client.GetAsync(baseAddress + "files").Result;
                HandleResponse(response);
            }

            Console.WriteLine("Using shared key authentication");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.SetSharedKey("banana");

                var response = client.GetAsync(baseAddress + "files").Result;
                HandleResponse(response);
            }

            Console.ReadLine();
        }

        private static void HandleResponse(HttpResponseMessage response)
        {
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }


    }
}