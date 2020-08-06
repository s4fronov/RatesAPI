using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

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
            return RatesContainer.GetInstance().Rates;
        }
    }
}
