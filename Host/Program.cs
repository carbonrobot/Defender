namespace Host
{
    using System;
    using Microsoft.Owin.Hosting;

    public class Program
    {
        private static void Main(string[] args)
        {
            // host the api on port 9000
            var baseAddress = "http://localhost:9000/";
            using (WebApp.Start<WebApi.Startup>(url: baseAddress))
            {
                Console.WriteLine("Server online at " + baseAddress);
                Console.ReadLine();
            }
        }
    }
}