using Microsoft.Extensions.Configuration;

namespace Rates.API
{
    public class Configurations
    {
        private readonly IConfiguration _configuration;

        public Configurations(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string exchangeUrl { get { return _configuration["ExhangeUrl"]; } set {; } }
        public string exchangeHost { get { return _configuration["ExchangeHost"]; } set {; } }
        public string filepath { get { return _configuration["FilePath"]; } set {; } }
        public string rabbitMQHost { get { return _configuration["RabbitMQHost"]; } set {; } }
        public string userName { get { return _configuration["UserName"]; } set {; } }
        public string password { get { return _configuration["Password"]; } set {; } }
    }
}
