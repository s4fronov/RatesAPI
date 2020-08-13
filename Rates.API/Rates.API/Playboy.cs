﻿using MassTransit;
using Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rates.API
{
    public class Playboy
    {
        ConvertationFromJson curr = new ConvertationFromJson();
        public IBusControl GetConnectionBus() 
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
            return bus;
        }

        public async Task PublishRates(IBusControl bus) 
        {
            var currencies = curr.GetModel();
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