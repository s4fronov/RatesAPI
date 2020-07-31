using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Rates.API
{
    public class Ratesrequest
    {
        public static string SendingRequest()
        {
            string _responseText;
                       
            WebRequest request = WebRequest.Create("https://api.exchangeratesapi.io/latest?base=RUB&symbols=USD,EUR,JPY");
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
