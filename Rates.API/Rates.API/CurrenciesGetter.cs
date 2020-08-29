using Newtonsoft.Json;

namespace Rates.API
{
    public class CurrenciesGetter
    {
        private string _exchangeUrl;
        private string _exchangeHost;

        public CurrenciesGetter(string exchangeUrl, string exchangeHost)
        {
            _exchangeUrl = exchangeUrl;
            _exchangeHost = exchangeHost;
        }
        
        public ExchangeRateModel GetModel()
        {
            var currenRates = CurrencyRates.getInstance();
            ExchangeRateModel currencies = JsonConvert.DeserializeObject<ExchangeRateModel>(currenRates.GetRates(_exchangeUrl,_exchangeHost));
            return currencies;
        }
    }
}
