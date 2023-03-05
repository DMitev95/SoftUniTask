using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs.Products
{
    public class ExportUsersSoldProductDtop
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("price")]
        public decimal price { get; set; }

        [JsonProperty("buyerFirstName")]
        public string buyerFirstName { get; set; }

        [JsonProperty("buyerLastName")]
        public string buyerLastName { get; set; }

    }
}
