using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EventCatalogAPI
{
    public class Program
    {
        //Notes:IIS - Internet Information service - a piece of software  in windows that hosts web application.Similar to Tomcat in Linux
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            //Here we are creating a large object so we need to let garbage colelctor know we dont need this anymore.
            //Here when we reach the end of using statement we dont want scope anymore as scope can be alarge object
            using (var scope = host.Services.CreateScope())//Wait until my Database is creted before seeding
            {

                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<EventContext>();//tell me if DB's created by EventContext  is there
                EventSeed.SeedAsync(context).Wait();

            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
