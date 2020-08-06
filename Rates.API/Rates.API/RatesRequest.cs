using System.IO;
using System.Net;

namespace Rates.API
{
    public class RatesRequest
    {
        public static string GetRates()
        {
            string _responseText;
                       
            WebRequest request = WebRequest.Create("http://data.fixer.io/api/latest?access_key=bf01a2ff20ebff3a52221f39e4500112&symbols=USD,RUB,JPY");
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
