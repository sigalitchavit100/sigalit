using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Avensia.Storefront.Developertest
{
    public class DefaultProductDto : IProductDto
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        // Ability to change the property to match the json data
        [JsonProperty("ProductName")]
        public string ProductName { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("CategoryId")]
        public string CategoryId { get; set; }

        public List<JObject> Properties { get; set; }
    }
}