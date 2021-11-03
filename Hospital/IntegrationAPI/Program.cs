using IntegrationLibrary.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static List<Pharmacy> Pharmacies = new List<Pharmacy>()
        {
            new Pharmacy(1 , "someUrl", "pharmacy1", "someAddress", "someApiKey"),
            new Pharmacy(2 , "someUrl", "pharmacy2", "someAddress", "someApiKey"),
            new Pharmacy(3 , "someUrl", "pharmacy3", "someAddress", "someApiKey")
        };

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
