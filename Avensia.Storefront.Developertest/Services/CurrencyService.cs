using Avensia.Storefront.Developertest.Interfaces;

namespace Avensia.Storefront.Developertest.Services
{
    public class CurrencyService : ICurrencyService
    {
        public decimal ToUserCurrency(decimal rate, decimal price)
        {
            return rate * price;
        }
    }
}
