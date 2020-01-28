using Avensia.Storefront.Developertest.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avensia.Storefront.Developertest.Services
{
    public class JsonReaderService
    {
        public static List<DefaultProductDto> ReadJson(string resource)
        {
            // Todo: Validation, try catch , or throw my exception
            // Todo: Validating with JSON Schema
            return JsonConvert.DeserializeObject<List<DefaultProductDto>>(File.ReadAllText(resource));
        }
    }
}
