using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Facemask.Models;
using Facemask.Services.ProductEngine;
using Facemask.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Facemask.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueThumbnailFileName = null;
                string uniqueImageFileName = null;
                string thumbnailFilePathToDb = null;
                string imageFilePathToDb = null;
                if (model.Thumbnail != null && model.Image != null)
                {
                    string thumbnailUploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Thumbnails");
                    string imagesUploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    uniqueThumbnailFileName = Guid.NewGuid().ToString() + "_" + DateTime.Now.ToString() + "_" + model.Thumbnail.FileName;
                    uniqueImageFileName = Guid.NewGuid().ToString() + "_" + DateTime.Now.ToString() + "_" + model.Image.FileName;

                    //thumnail File path to be store in DB
                    thumbnailFilePathToDb = Path.Combine(thumbnailUploadsFolder, uniqueThumbnailFileName);
                    imageFilePathToDb = Path.Combine(imagesUploadsFolder, uniqueImageFileName);

                    //upload to server
                    model.Thumbnail.CopyTo(new FileStream(thumbnailFilePathToDb, FileMode.Create));
                    model.Image.CopyTo(new FileStream(imageFilePathToDb, FileMode.Create));


                }
                //save a new Product
                Product newProduct = new Product
                {
                    Sku = model.Sku,
                    Name = model.Name,
                    Weight = model.Weight,
                    Descriptions = model.Descriptions,
                    Thumbnail = thumbnailFilePathToDb,
                    Image = imageFilePathToDb,
                    Category = model.Category,
                    CreatedDate = DateTime.Now,
                    Stock = model.Stock

                };

                _productService.AddSingleProduct(newProduct);
                //return RedirectToAction(nameof(Detail), new { Id = newProduct.Id });
                return RedirectToAction(nameof(DetailBySlug), new { Slug = newProduct.Slug });
            }

            return View();
        }

        [HttpGet("{Id}")]
        public IActionResult Detail(int Id)
        {
            Product productToView = _productService.GetSingleProduct(Id);
            return View(productToView);
        }

        [HttpGet("{Slug}")]
        public IActionResult DetailBySlug(string Slug)
        {
            Product productToView = _productService.GetProductBySlug(Slug);
            return View(productToView);
        }

        [HttpPut("{Id}")]
        public IActionResult Edit(int Id)
        {
            Product productToUpdate = _productService.GetSingleProduct(Id);
            if(productToUpdate != null)
            {
                _productService.UpdateProduct(productToUpdate);
                ViewBag.Message = "Product Updated Successfully!";
            }
            else
            {
                ViewBag.Message = "Product not found";
            }
            
            return View();
        }


    }
}
