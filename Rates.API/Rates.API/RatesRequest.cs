using System.IO;
using System.Net;

namespace Rates.API
{
    public class RatesRequest
    {
        public static string GetRates()
        {
            string _responseText;
                       
            WebRequest request = WebRequest.Create(AddressProfile.api);
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream);
                _responseText = reader.ReadToEnd();         
            }
            return _responseText;
        }
    }
}
