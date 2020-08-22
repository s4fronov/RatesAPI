using System;
using System.Threading.Tasks;
using System.Timers;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rates.API.Models;
using Timer = System.Timers.Timer;

namespace Rates.API
{
    public class Program

    {
        private static Timer aTimer;
        private static IConfiguration Configuration { get; set; }
        static int seconds = 0;

        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);                     
            Configuration = builder.Build();
            var exchangeUrl = Configuration["ExhangeUrl"];
            var exchangeHost = Configuration["ExchangeHost"];

            CurrenciesGetter curGetter = new CurrenciesGetter(exchangeUrl, exchangeHost);
            var exchangeRateModel = curGetter.GetModel();

            aTimer = new Timer();
            aTimer.Interval = 30000;
            aTimer.Start();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);



            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();            

            //Console.OutputEncoding = Encoding.UTF8;
            //Playboy playboy = new Playboy();
            //var bus = playboy.GetConnectionBus();
            //bus.Start();
            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromMinutes(60);
            //var timer = new Timer(async (e) =>    //добавить обработчики getModel, publishRates и logRates через событие elapsed
            //{
            //    await playboy.PublishRates(bus); // поработать с событиями!!!!!
            //}, null, startTimeSpan, periodTimeSpan);
            //Console.ReadKey();
            //bus.Stop();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            seconds++;
        }
        
    }
}
    