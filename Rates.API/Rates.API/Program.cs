using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rates.API.Controllers;

namespace Rates.API
{
    public class Program
    {
        //public static object JsonConvert { get; private set; }

        public static void Main(string[] args)
        {
            Rates currencies = new Rates();                    
            string Filepath = @"D:\currency.txt";
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(60);

            var timer = new Timer((e) =>
            {
            string currencyRates = RatesRequest.GetRates();
            string[] data = Regex.Split(currencyRates, @"\D+");
            currencies.time = new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt32(data[1]));
            var time = Convert.ToString(currencies.time);
            currencies.USD = Convert.ToDouble(data[5] + "," + data[6]);
            currencies.RUB = Convert.ToDouble(data[7] + "," + data[8]);
            currencies.JPY = Convert.ToDouble(data[9] + "," + data[10]);
            string currenciesData = "DateOfChanges: "+ time + "; USD = " +(data[5] + "," + data[6]) + "; RUB = " + (data[7] + "," + data[8]) + "; JPY = " + (data[9] + "," + data[10]);
            var jsonContent = new StringContent(JsonConvert.SerializeObject(currencies), Encoding.UTF8, "application/json");
            File.AppendAllText(Filepath, currenciesData +"\n");
                

            }, null, startTimeSpan, periodTimeSpan);
            

            Console.ReadKey();
        }

       



    }
}
