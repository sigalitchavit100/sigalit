using Avensia.Storefront.Developertest.Interfaces;
using Avensia.Storefront.Developertest.MockData;
using System;
using System.Collections.Generic;

namespace Avensia.Storefront.Developertest
{
    public class ProductListVisualizer
    {
        #region private members
        private readonly IProductRepository _productRepository;
        private ICurrencyService _currencyService;
        private int _currencyCode = 1; // As requested, USD is the default
        public int PriceSegmentDevider = 100;
        private readonly string resource = @"MockData/products.json"; // An asuumption otherwise it should be taken from a config file or user prompt
        #endregion

        #region Ctor

        // Using Ctor just from test project
        public ProductListVisualizer(IProductRepository productRepository, ICurrencyService currencyService)
        {
            _productRepository = productRepository;
            _currencyService = currencyService;
        }
        #endregion

        #region Private methods
        private string ProductToString(IProductDto product)
        {
            return $"{product.Id}\t{product.ProductName}\t{product.CategoryId}" +
                $"\tPrice: {_currencyService.ToUserCurrency(CurrencyMatrixData.CurrencyMockRate[_currencyCode - 1], product.Price)}";
        }

        private void PrintProducts(IEnumerable<IProductDto> products)
        {
            if (products != null)
            {
                foreach (var product in products)
                {
                    Console.WriteLine(ProductToString(product));
                }
            }
        }

        #endregion

        #region Public methods
        public void SetCurrencyCode(int currencyCode)
        {
            // Validation goes here !!
            _currencyCode = currencyCode;
        }

        public void OutputAllProducts()
        {
            PrintProducts(_productRepository.GetProducts(resource));
        }

        public void OutputPaginatedProducts(int start, int pageSize)
        {
            _productRepository.GetProducts(resource); // Will not read it from json, if it's allready cached!
            if (pageSize > _productRepository.TotalDataSet)
                pageSize = _productRepository.TotalDataSet;

            do
            {
                Console.WriteLine($"Pages: [{start} - {start + pageSize}]");
                PrintProducts(_productRepository.GetProducts(resource, start, pageSize));
                start += pageSize;
            }
            while ((start + pageSize) <= _productRepository.TotalDataSet);

            if (start < _productRepository.TotalDataSet && (start + pageSize) > _productRepository.TotalDataSet)
            {
                pageSize = _productRepository.TotalDataSet - start;
                Console.WriteLine($"Pages: [{start} - {start + pageSize}]");
                PrintProducts(_productRepository.GetProducts(resource, start, pageSize));
            }
        }

        public void OutputProductGroupedByPriceSegment()
        {
            _productRepository.GetProducts(resource);
            foreach (int priceSegment in _productRepository.ProductDictionaryGroupedByPrice.Keys)
            {
                Console.WriteLine("{0} - {1}", priceSegment, priceSegment + PriceSegmentDevider);

                foreach (var product in _productRepository.ProductDictionaryGroupedByPrice[priceSegment])
                {
                    Console.Write("\t");
                    Console.WriteLine(ProductToString(product));
                }
            }
        }
        #endregion
    }
}