using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avensia.Storefront.Developertest;
using Avensia.Storefront.Developertest.Interfaces;
using Avensia.Storefront.Developertest.Services;
using System.Linq;

namespace UnitTestAvensia
{
    [TestClass]
    public class AvensiaTests
    {
        string resource;

        [TestInitialize]
        public void TestInitialize()
        {
            resource = @"MockData/products.json";

        }

        [TestMethod]
        public void TestReadJson()
        {
            // Arrange

            // Act
            var res = JsonReaderService.ReadJson(resource);

            // Assert
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TestReadJsonCount()
        {
            // Arrange

            // Act
            var res = JsonReaderService.ReadJson(resource);

            // Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count == 20);
        }

        [TestMethod]
        public void TestGetProducts()
        {
            // Arrange
            IProductRepository productRepository = new DefaultExampleProductRepository();


            // Act
            var products = productRepository.GetProducts(resource);

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count() == 20);
        }

        [TestMethod]
        public void TestGetProductsPagination0_5()
        {
            // Arrange
            IProductRepository productRepository = new DefaultExampleProductRepository();
            int start = 0, pageSize = 5;

            // Act
            var products = productRepository.GetProducts(resource, start, pageSize);

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count() == 5);
        }

        [TestMethod]
        public void TestGetProductsPagination3_3()
        {
            // Arrange
            IProductRepository productRepository = new DefaultExampleProductRepository();
            int start = 3, pageSize = 3;

            // Act
            var products = productRepository.GetProducts(resource, start, pageSize);

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count() == 3);
        }

        [TestMethod]
        public void TestOutputPaginatedProductsOutOfBound1()
        {
            // make some fakes for the test
            IProductRepository productRepository = new DefaultExampleProductRepository();
            ICurrencyService currencyService = new CurrencyService();
            var productListVisualizer = new ProductListVisualizer(productRepository, currencyService);

            // Act
            productListVisualizer.SetCurrencyCode(1);

            try
            {
                productListVisualizer.OutputPaginatedProducts(-11, 5);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message); // If it gets to this line, no exception was thrown
            }
        }

        [TestMethod]
        public void TestOutputPaginatedProductsOutOfBound2()
        {
            // make some fakes for the test
            IProductRepository productRepository = new DefaultExampleProductRepository();
            ICurrencyService currencyService = new CurrencyService();
            var productListVisualizer = new ProductListVisualizer(productRepository, currencyService);

            // Act
            productListVisualizer.SetCurrencyCode(1);

            try
            {
                productListVisualizer.OutputPaginatedProducts(11, 500);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message); // If it gets to this line, no exception was thrown
            }
        }

        [TestMethod]
        public void TestOutputPaginatedProductsRemainings()
        {
            // make some fakes for the test
            IProductRepository productRepository = new DefaultExampleProductRepository();
            ICurrencyService currencyService = new CurrencyService();
            var productListVisualizer = new ProductListVisualizer(productRepository, currencyService);

            // Act
            productListVisualizer.SetCurrencyCode(1);

            try
            {
                productListVisualizer.OutputPaginatedProducts(0, 18);
            }
            catch(Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message); // If it gets to this line, no exception was thrown
            }
        }

    }
    
}
