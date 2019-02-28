using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace DijleZonenApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddEnvironmentVariables()
           //.AddJsonFile("certificate.json", optional: true, reloadOnChange: true)
           //.AddJsonFile($"certificate.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
           .Build();

            //var certificateSettings = config.GetSection("certificateSettings");
            //string certificateFileName = certificateSettings.GetValue<string>("filename");
            //string certificatePassword = certificateSettings.GetValue<string>("password");

            //var certificate = new X509Certificate2(certificateFileName, certificatePassword);
            //BuildWebHost(args, certificate).Run();
            BuildWebHost(args).Run();
        }
        // ASP.NET Core project templates use Kestrel by default. 
        // In Program.cs, the template code calls CreateDefaultBuilder, which calls UseKestrel behind the scenes.
        public static IWebHost BuildWebHost(string[] args/*, X509Certificate2 certificate*/) =>

            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://0.0.0.0:8883")
                /*.UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 8883);
                    options.Listen(IPAddress.Loopback, 8881, listenOptions =>
                    {
                       listenOptions.UseHttps(certificate);
                    });
                })*/
                .Build();
    }
}
