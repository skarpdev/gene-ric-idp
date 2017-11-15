using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace kewlthing_csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseUrls("http://*:5500")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
