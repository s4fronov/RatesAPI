using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rates.API.Models
{
    public interface IUrlOptions
    {
         string ExhangeUrl { get; set; }
         string  ExhangeHost { get; set; }

    }
}

