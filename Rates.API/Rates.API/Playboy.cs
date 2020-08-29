using MassTransit;
using Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rates.API
{
    public class Playboy
    {
        private readonly string _rabbitMQHost;
        private readonly string _userName;
        private readonly string _password;

        public Playboy(string rabbitMQHost, string userName, string password)
        {
            _rabbitMQHost = rabbitMQHost;
            _userName = userName;
            _password = password;
        }

        public IBusControl GetConnectionBus() 
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(_rabbitMQHost, "/", h => 
                { 
                    h.Username(_userName);   
                    h.Password(_password); 
                }); 
            });
            return bus;
        }

        public async Task PublishRates(IBusControl bus, ExchangeRateModel currencies)
        {
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
        }
    }
}
