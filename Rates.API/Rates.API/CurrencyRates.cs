using RestSharp;

namespace Rates.API
{
    public class CurrencyRates
    {
        private static CurrencyRates instance;

        private CurrencyRates() { }
      
        public static string GetRates()
        {           
            var restClient = new RestClient(AddressProfile.api);
            var restRequest = new RestRequest(AddressProfile.url, Method.GET, DataFormat.Json);            
            return restClient.Execute<string>(restRequest).Data;           
            // здесь херачим singleton
        }
    }
    //class Singleton
    //{
    //    private static Singleton instance;

    //    private Singleton()
    //    { }

    //    public static Singleton getInstance()
    //    {
    //        if (instance == null)
    //            instance = new Singleton();
    //        return instance;
    //    }
    //}    
}
