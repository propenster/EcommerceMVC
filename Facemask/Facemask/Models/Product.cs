using Newtonsoft.Json;
using Slugify;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Facemask.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("sku")]
        public string Sku { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("slug")]
        public string? Slug { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("weight")]
        public int Weight { get; set; }
        [JsonProperty("descriptions")]
        public string Descriptions { get; set; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        //[JsonProperty("category")]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("stock")]
        public int Stock { get; set; }



        public Product()
        {
            var config = new SlugHelperConfiguration();
            config.StringReplacements.Add(" ", "-");
            config.ForceLowerCase = true;
            config.CollapseDashes = true;
            config.TrimWhitespace = true;
            config.CollapseWhiteSpace = true;
            config.DeniedCharactersRegex = @"[^a-zA-Z0-9\-\._]";
            SlugHelper helper = new SlugHelper(config);
            Slug = helper.GenerateSlug(Name);
        }

    }

            
}
