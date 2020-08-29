using System.IO;

namespace Rates.API
{
    public class CurrenciesLogger
    {
        public void LogCurrencies(ExchangeRateModel currencies)
        {
            string _filepath = @"./currency.txt"; // уже в конфигурации (когда json заработает убрать отсюда)
            string currenciesData = "DateOfChanges: " + 
                                    currencies.Time.ToString("dd.MM.yyyy HH:mm:ss") + 
                                    "; USD = " + currencies.Rates.USD +         
                                    "; JPY = " + currencies.Rates.JPY;
            File.AppendAllText(_filepath, currenciesData + "\n");
        }
    }
}
