using Avensia.Storefront.Developertest.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avensia.Storefront.Developertest
{
    public class DefaultExampleProductRepository : IProductRepository
    {
        private IEnumerable<IProductDto> _products;
        public SortedDictionary<int, List<IProductDto>> ProductDictionaryGroupedByPrice { get; private set; }
        public int TotalDataSet { get; private set; }
        #region Private methods
        private void InitDictionaryGroupedByPrice(IEnumerable<IProductDto> products)
        {
            ProductDictionaryGroupedByPrice = new SortedDictionary<int, List<IProductDto>>();

            foreach (var product in products)
            {
                int priceSegment = (int)(product.Price / 100) * 100;
                if (!ProductDictionaryGroupedByPrice.Keys.Contains(priceSegment))
                {
                    ProductDictionaryGroupedByPrice.Add(priceSegment, new List<IProductDto>());
                }
                ProductDictionaryGroupedByPrice[priceSegment].Add(product);
            }
        }
        #endregion

        #region Public methods
        public IEnumerable<IProductDto> GetProducts(string resource)
        {
            if (_products == null) // It's not cached yet !
            {
                try
                {
                    _products = JsonReaderService.ReadJson(resource);
                    TotalDataSet = _products.Count();
                    InitDictionaryGroupedByPrice(_products);
                }
                catch (Exception ex)
                {
                    // Add to my Logger
                    Logger logger = LogManager.GetLogger("MyLogger");
                    logger.Error(ex, "Failed to read json file");
                }
            }

            return _products;
        }

        public IEnumerable<IProductDto> GetProducts(string resource, int start, int pageSize)
        {
            return GetProducts(resource).Skip(start).Take(pageSize);
        }
        #endregion
    }
}