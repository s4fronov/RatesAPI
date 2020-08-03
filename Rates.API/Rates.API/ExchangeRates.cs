using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rates.API
{
    public class ExchangeRates
    {
        public bool Success { get; set; }

        public DateTime Timestamp { get; set; }

        public string Base { get; set; }

        public DateTime Date { get; set; }

        public List<Rates> Rates { get; set; }
    }
}
