namespace ConsoleHost
{
    using System;
    using Microsoft.Owin.Hosting;
    using WebApi;

    public class Program
    {
        private static void Main(string[] args)
        {
            // host the api on port 9000
            var baseAddress = "http://localhost:9000/";
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Server online at " + baseAddress);
                Console.ReadLine();
            }
        }
    }
}