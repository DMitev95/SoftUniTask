using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop.DTOs.Categories
{
    public class ImportCategoriesDto
    {
        [JsonProperty("Name")]
        [Required]
        public string name { get; set; }
    }
}
