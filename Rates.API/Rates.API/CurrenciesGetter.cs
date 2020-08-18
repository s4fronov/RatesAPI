using Newtonsoft.Json;

namespace Rates.API
{
    public class CurrenciesGetter
    {        
        public ExchangeRateModel GetModel()
        {
            CurrencyRates currencyRates = CurrencyRates.getInstance();            
            ExchangeRateModel currencies = JsonConvert.DeserializeObject<ExchangeRateModel>(currencyRates.GetRates());            
            return currencies;
        }
    }
}
