
namespace Rates.API
{
    public class RatesContainer
    {
        public string Rates { get; set; }

        //singleton
        private static RatesContainer instance;

        private RatesContainer() { }

        public static RatesContainer GetInstance()
        {
            if (instance == null)
                instance = new RatesContainer();
            return instance;
        }
    }
}
