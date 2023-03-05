using Newtonsoft.Json;
using ProductShop.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs.User
{
    public class ExportUsersWithSoldProductDto
    {
        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("soldProducts")]
        public ExportUsersSoldProductDtop[] soldProducts { get;set;}
    }
}
