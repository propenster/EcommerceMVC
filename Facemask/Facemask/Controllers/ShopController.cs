using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Facemask.Models;
using Facemask.Services.ProductEngine;
using Facemask.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Facemask.Controllers
{
    public class ShopController : Controller
    {

        private readonly IProductService _productService;
        IMapper _mapper;

        public ShopController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        //Shop Home
        public IActionResult Index()
        {
            IEnumerable<Product> products = _productService.GetAllProducts();
            var productsToView = _mapper.Map<IEnumerable<ProductDetailViewModel>>(products);
            //ViewBag.ProductList = productsToView;
            return View(productsToView);
        }

        [HttpGet]
        public IActionResult Detail(string Slug)
        {
            Product product = _productService.GetProductBySlug(Slug);
            var productToView = _mapper.Map<ProductDetailViewModel>(product);
            ViewBag.ProductItem = productToView;
            return View();
        }


    }
}
