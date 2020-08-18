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
                _instance = new CurrencyRates();
            return _instance;
        }

        public string GetRates()
        {           
            var restClient = new RestClient(AddressProfile.api);
            var restRequest = new RestRequest(AddressProfile.url, Method.GET, DataFormat.Json);            
            return restClient.Execute<string>(restRequest).Data;           
            // здесь херачим singleton, тут будет инстанс и сам метод
        }
    }
    
}
