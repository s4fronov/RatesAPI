using System;
using System.Collections.Generic;
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
            ExchangeRateModel currencies = new ExchangeRateModel();
            string Filepath = @"C:\currency.txt";
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(60);           
            var timer = new Timer(async(e) =>
            {
                string currencyRates = CurrencyRates.GetRates();
                currencies = JsonConvert.DeserializeObject<ExchangeRateModel>(currencyRates);                
                string currenciesData = "DateOfChanges: " + currencies.Time.ToString("dd.MM.yyyy HH:mm:ss") + "; USD = " + currencies.Rates.USD + "; RUB = " + currencies.Rates.RUB + "; JPY = " + currencies.Rates.JPY;
                File.AppendAllText(Filepath, currenciesData + "\n");
                await bus.Publish<Currencies>(new 
                { 
                    Rates = new List<Currency> 
                    {
                        new Currency { Code = "EUR", Rate = 1 },
                        new Currency { Code = "USD", Rate = currencies.Rates.USD }, 
                        new Currency { Code = "RUB", Rate = currencies.Rates.RUB }, 
                        new Currency { Code = "JPY", Rate = currencies.Rates.JPY }
                    } 
                });                
            }, null, startTimeSpan, periodTimeSpan);
            Console.ReadKey();
            bus.Stop();
        }
    }
}
    