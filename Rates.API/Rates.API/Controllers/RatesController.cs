using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rates.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatesController : ControllerBase
    {            
        private static readonly HttpClient _httpClient;

        static RatesController()
        {
            _httpClient = new HttpClient();
        }
                
        [HttpGet]
        public string GetCurrencyRates()
        {            
            return Ratesrequest.SendingRequest();
        }

    }
}
