using Facemask.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required]
        public string Sku { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public string Descriptions { get; set; }
        [Required]
        public IFormFile Thumbnail { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public Category Category { get; set; } //Set Category Name in here...
        [Required]
        public int Stock { get; set; }

    }
}
