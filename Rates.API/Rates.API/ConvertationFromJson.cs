using Newtonsoft.Json;
using System.IO;

namespace Rates.API
{
    public class ConvertationFromJson
    {
        ExchangeRateModel currencies = new ExchangeRateModel();
        string Filepath = @"C:\currency.txt";
        public ExchangeRateModel GetModel()
        {
            string currencyRates = CurrencyRates.GetRates();
            currencies = JsonConvert.DeserializeObject<ExchangeRateModel>(currencyRates);
            string currenciesData = "DateOfChanges: " + currencies.Time.ToString("dd.MM.yyyy HH:mm:ss") + "; USD = " + currencies.Rates.USD + "; RUB = " + currencies.Rates.RUB + "; JPY = " + currencies.Rates.JPY;
            File.AppendAllText(Filepath, currenciesData + "\n");
            return currencies;
        }
    }
}
