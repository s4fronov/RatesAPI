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
            RatesContainer rc = RatesContainer.GetInstance();
            
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(60);

            var timer = new Timer((e) =>
            {
               rc.Rates = RatesRequest.GetRates();
            }, null, startTimeSpan, periodTimeSpan);
            Console.ReadKey();
        }
    }
}
