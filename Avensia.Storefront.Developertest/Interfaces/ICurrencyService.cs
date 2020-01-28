namespace Avensia.Storefront.Developertest.Interfaces
{
    public interface ICurrencyService
    {
        decimal ToUserCurrency(decimal rate, decimal price);
    }
}
