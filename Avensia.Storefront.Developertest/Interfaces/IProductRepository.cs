using System.Collections.Generic;

namespace Avensia.Storefront.Developertest
{
    public interface IProductRepository
    {
        IEnumerable<IProductDto> GetProducts(string resource);
        IEnumerable<IProductDto> GetProducts(string resource, int start, int pageSize);
        SortedDictionary<int, List<IProductDto>> ProductDictionaryGroupedByPrice { get; }
        int TotalDataSet { get; } // In C# 7.3 and above I could use accesor like private
    }
}