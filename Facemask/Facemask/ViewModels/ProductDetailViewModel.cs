using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.ViewModels
{
    public class ProductDetailViewModel
    {

        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string? Slug { get; set; }
        public decimal Price { get; set; }
        public int Weight { get; set; }
        public string Descriptions { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        //[JsonProperty("category")]
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Stock { get; set; }

    }
}
