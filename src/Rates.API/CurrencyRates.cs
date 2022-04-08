using RestSharp;

namespace Rates.API
{
    public class CurrencyRates
    {
        private static CurrencyRates _instance;    
        private CurrencyRates() { }

        public static CurrencyRates getInstance()
        {
            if (_instance == null)
            {
                _instance = new CurrencyRates();    
            }
            return _instance;
        }

        public string GetRates(string _exchangeUrl, string _exchangeHost)
        {           
            var restClient = new RestClient(_exchangeHost);
            var restRequest = new RestRequest(_exchangeUrl, Method.GET, DataFormat.Json);            
            return restClient.Execute<string>(restRequest).Data;    
        }
    }
}
