using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Messaging;
using Newtonsoft.Json;

namespace Rates.API
{
    public class Program
    {
       
        static async Task Main(string[] args)
        {
            ExchangeRateModel currencies = new ExchangeRateModel();
            string Filepath = @"D:\currency.txt";
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(60);           
            var timer = new Timer(async(e) =>
            {
                string currencyRates = RatesRequest.GetRates();
                currencies = JsonConvert.DeserializeObject<ExchangeRateModel>(currencyRates);                
                string currenciesData = "DateOfChanges: " + currencies.Time.ToString("dd.MM.yyyy HH:mm:ss") + "; USD = " + currencies.Rates.USD + "; RUB = " + currencies.Rates.RUB + "; JPY = " + currencies.Rates.JPY;
                File.AppendAllText(Filepath, currenciesData + "\n");                
                Console.OutputEncoding = Encoding.UTF8;            

                var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                });

                bus.Start();
                await bus.Publish<CurrencyRates>(new { USD = currencies.Rates.USD, RUB = currencies.Rates.RUB, JPY = currencies.Rates.JPY });
                bus.Stop();
            }, null, startTimeSpan, periodTimeSpan);
            Console.ReadKey();
        }
    }
}
