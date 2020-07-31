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
        private string _currencyRates = "";
        private static readonly HttpClient _httpClient;

        static RatesController()
        {
            
            _httpClient = new HttpClient();

        }

        [HttpGet]

        public async void ReceiveCurrencyRates()
        {
            var response = await _httpClient.GetAsync("https://api.exchangeratesapi.io/latest?base=RUB&symbols=USD,EUR,JPY");
            _currencyRates = await response.Content.ReadAsStringAsync();
            //StatusCode((int)response.StatusCode, content)
        }
        [HttpGet("receive")]
        public async Task<string> SendCurrencyRates()
        {
           
            return _currencyRates;
        }

    }
}
