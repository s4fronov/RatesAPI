using Newtonsoft.Json;
using System.IO;

namespace Rates.API
{
    public class CurrenciesGetter
    {        
        public ExchangeRateModel GetModel()
        {
            string currencyRates = CurrencyRates.GetRates();
            ExchangeRateModel currencies = JsonConvert.DeserializeObject<ExchangeRateModel>(currencyRates);            
            return currencies;
        }

        public void AddRateToTheTextFile(ExchangeRateModel currencies)
        {
           string _filepath = @"C:\currency.txt";
           string currenciesData = "DateOfChanges: " + //
                currencies.Time.ToString("dd.MM.yyyy HH:mm:ss") + //
                "; USD = " + currencies.Rates.USD + //          вынести этот метод куда-нибудь
                "; RUB = " + currencies.Rates.RUB + //
                "; JPY = " + currencies.Rates.JPY;//
            File.AppendAllText(_filepath, currenciesData + "\n");//
        }
    }
}
