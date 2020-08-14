using Newtonsoft.Json;
using System.IO;

namespace Rates.API
{
    public class CurrenciesGetter
    {
        private const string _filepath = @"C:\currency.txt";
        public ExchangeRateModel GetModel()
        {
            string currencyRates = CurrencyRates.GetRates();
            ExchangeRateModel currencies = JsonConvert.DeserializeObject<ExchangeRateModel>(currencyRates);
            string currenciesData = "DateOfChanges: " + //
                currencies.Time.ToString("dd.MM.yyyy HH:mm:ss") + //
                "; USD = " + currencies.Rates.USD + //          переделать в отдельный метод
                "; RUB = " + currencies.Rates.RUB + //
                "; JPY = " + currencies.Rates.JPY;//
            File.AppendAllText(_filepath, currenciesData + "\n");//
            return currencies;
        }
    }
}
