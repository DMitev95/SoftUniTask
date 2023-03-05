using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs.Categories_Products
{
    public class ImportCategoriesProductsDto
    {
        [JsonProperty(nameof(CategoryId))]
        public int CategoryId { get; set; }
        [JsonProperty(nameof(ProductId))]
        public int ProductId { get; set; }
    }
}
