using System.IO;

namespace Rates.API
{
    public class CurrenciesLogger
    {
        private readonly string _filepath;
        public CurrenciesLogger(string filepath)
        {
            _filepath = filepath;
        }
        public void LogCurrencies(ExchangeRateModel currencies)
        {            
            string currenciesData = "DateOfChanges: " + 
                                    currencies.Time.ToString("dd.MM.yyyy HH:mm:ss") + 
                                    "; USD = " + currencies.Rates.USD +
                                    "; RUB = " + currencies.Rates.RUB +
                                    "; JPY = " + currencies.Rates.JPY;
            File.AppendAllText(_filepath, currenciesData + "\n");
        }
    }
}
