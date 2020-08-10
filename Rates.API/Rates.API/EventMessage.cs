using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rates.API
{
    public interface EventMessage
    {
        public string Text { get; set; }
    }
}
