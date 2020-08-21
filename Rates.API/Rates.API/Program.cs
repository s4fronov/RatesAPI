using System;

using System.Threading.Tasks;
using System.Timers;
using MassTransit;
using Microsoft.AspNetCore.Hosting;

using Timer = System.Timers.Timer;

namespace Rates.API
{
    public class Program
    {
        private static Timer aTimer;
        static async Task Main(string[] args)
        {
            aTimer = new Timer();          
           
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            
            aTimer.Interval = 30000;
            aTimer.Enabled = true;

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
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        }

        //public void CreateTimer()
        //{
        //    var timer = new System.Timers.Timer(1000); // fire every 1 second
        //    timer.Elapsed += HandleTimerElapsed;
        //}

        //public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        //{
        //    // do whatever it is that you need to do on a timer
        //}

    }
}
    