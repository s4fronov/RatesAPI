using System;
using System.IO;
using System.Text;
using System.Threading;
using MassTransit;
using Newtonsoft.Json;

namespace Rates.API
{
    public class Program
    {
        //public static object JsonConvert { get; private set; }

        static async Task Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            string host = "host";
            string vhost = "vhost";
            string username = "username";
            string password = "password";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                IRabbitMqHost rmqHost = cfg.Host(host, vhost, h =>
                {
                    h.Username(username);
                    h.Password(password);
                });
            });

            bus.Start();

            Console.WriteLine("Нажмите Enter, чтобы опубликовать событийное сообщение.");
            Console.ReadKey();

            await bus.Publish<EventMessage>(new { Text = "Событийное сообщение: приходит ко всем потребителям." });

            Console.WriteLine("Нажмите Enter, чтобы опубликовать соревновательное сообщение.");
            Console.ReadKey();

            await bus.Publish<CompetingConsumersMessage>(new { Text = "Соревновательное сообщение: принимается только одним из подписчиков очереди." });

            Console.ReadKey();

            bus.Stop();
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
