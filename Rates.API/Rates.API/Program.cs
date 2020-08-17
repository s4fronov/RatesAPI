using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Hosting;

namespace Rates.API
{
    public class Program
    {        
        static async Task Main(string[] args)
        {            
            Console.OutputEncoding = Encoding.UTF8;
            Playboy playboy = new Playboy();
            var bus = playboy.GetConnectionBus();
            bus.Start();
            var startTimeSpan = TimeSpan.Zero; //
            var periodTimeSpan = TimeSpan.FromMinutes(60); //     
            var timer = new Timer(async(e) => //    добавить обработчики getModel, publishRates и logRates через событие elapsed
            { //
                await playboy.PublishRates(bus); // поработать с событиями!!!!!
            }, null, startTimeSpan, periodTimeSpan); //
            Console.ReadKey();
            bus.Stop();
        }
    }
}
    