using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductShop.DTOs.Products
{
    public class ExportSoldProductsFullInfoDto
    {
        [JsonProperty("count")]
        public int ProductsCount => SoldProducts.Any() ? SoldProducts.Count() : 0;

        [JsonProperty("products")]
        public ExportSoldPRoductShortInfoDto[] SoldProducts { get; set; }
    }
}
