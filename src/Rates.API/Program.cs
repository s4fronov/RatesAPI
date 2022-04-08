using System;
using System.Threading.Tasks;
using System.Timers;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Timer = System.Timers.Timer;

namespace Rates.API
{
    public class Program
    {
        private static Timer aTimer;
        private static IConfiguration Configuration { get; set; }
        private static Playboy playboy;
        private static CurrenciesGetter currenciesGetter;
        private static CurrenciesLogger currenciesLogger;
        private static IBusControl bus;

        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);                     
            Configuration = builder.Build();
            Configurations configurations = new Configurations(Configuration);
           
            playboy = new Playboy(configurations.rabbitMQHost, configurations.userName, configurations.password);
            currenciesGetter = new CurrenciesGetter(configurations.exchangeUrl, configurations.exchangeHost);
            currenciesLogger = new CurrenciesLogger(configurations.filepath);

            bus = playboy.GetConnectionBus();
            bus.Start();      
            
            var currencies = currenciesGetter.GetModel();
            await playboy.PublishRates(bus, currencies);
            currenciesLogger.LogCurrencies(currencies);

            aTimer = new Timer();
            aTimer.Interval = 3600000;
            aTimer.Elapsed += OnTimedEvent;           
            aTimer.Start();
            Console.WriteLine("Press the Enter key to exit the program at any time... ");
            Console.ReadLine();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var currencies = currenciesGetter.GetModel();
            playboy.PublishRates(bus, currencies);
            currenciesLogger.LogCurrencies(currencies);
        }
    }
}
    