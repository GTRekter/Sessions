using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GettingStartedWithASPNETCore.VisualBasic;

namespace GettingStartedWithASPNETCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO 0: References with other projects
            //var isPrime = Number.IsPrime(3);
            //Console.WriteLine(isPrime);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("Files/starship.json", optional: false, reloadOnChange: false);
                    config.AddXmlFile("Files/starship.xml", optional: false, reloadOnChange: false);
                    config.AddIniFile("Files/config.ini", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables(prefix: "PREFIX_");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
