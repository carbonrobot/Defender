namespace Client
{
    using System;
    using System.Net.Http;

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Press any key to begin the web api request");
            Console.ReadLine();
            
            // test the api
            var baseAddress = "http://localhost:9000/";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Basic JKHDLKSJHLKSJDH");

                var response = client.GetAsync(baseAddress + "files").Result;
                
                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        }
    }
}