using System;
using System.Globalization;

namespace Rates.API
{
    public class ExchangeRateModel
    {
        public int TimeStamp { get; set; }
        public DateTime Time { get { return new DateTime(1970, 1, 1).AddSeconds(TimeStamp); } set {; } }
        public RatesModel Rates { get; set; }

        
    }
}
