using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rates.API.Controllers;

namespace Rates.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string rates;
            
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(60);

            var timer = new Timer((e) =>
            {

               rates = Ratesrequest.SendingRequest();
            }, null, startTimeSpan, periodTimeSpan);


            CreateHostBuilder(args).Build().Run();
        }

      

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        
    }
}
