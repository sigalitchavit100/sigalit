using Avensia.Storefront.Developertest.Interfaces;
using Avensia.Storefront.Developertest.Services;
using StructureMap;

namespace Avensia.Storefront.Developertest
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<ProductListVisualizer>().Use<ProductListVisualizer>();
            For<IProductRepository>().Use<DefaultExampleProductRepository>();
            For<ICurrencyService>().Use<CurrencyService>();
        }
    }
}