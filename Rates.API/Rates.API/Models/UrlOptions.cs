using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rates.API.Models
{
    public class UrlOptions : IUrlOptions
    {
        public string ExhangeUrl { get; set; }
        public string ExhangeHost { get; set; }

    }
}
