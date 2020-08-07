using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace Rates.API
{
    public class Program
    {
        //public static object JsonConvert { get; private set; }

        public static void Main(string[] args)
        {
            ExchangeRateModel currencies = new ExchangeRateModel();
            string Filepath = @"D:\currency.txt";
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(60);
            var timer = new Timer((e) =>
            {
                string currencyRates = RatesRequest.GetRates();
                currencies = JsonConvert.DeserializeObject<ExchangeRateModel>(currencyRates);               
                string currenciesData = "DateOfChanges: " + currencies.Time.ToString("dd.MM.yyyy HH:mm:ss") + "; USD = " + currencies.Rates.USD + "; RUB = " + currencies.Rates.RUB + "; JPY = " + currencies.Rates.JPY;                
                File.AppendAllText(Filepath, currenciesData + "\n");
                Console.WriteLine(currencies.Time);
            }, null, startTimeSpan, periodTimeSpan);

            
            Console.ReadKey();
        }
    }
}
