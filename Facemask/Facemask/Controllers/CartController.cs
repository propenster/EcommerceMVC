using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facemask.Helpers;
using Facemask.Models;
using Facemask.Services.ProductEngine;
using Microsoft.AspNetCore.Mvc;

namespace Facemask.Controllers
{
    public class CartController : Controller
    {

        private readonly IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product?.Price * item?.Quantity);
            return View();
        }

        [Route("Add/{Id}")]
        public IActionResult Add(int Id)
        {
            var product = _productService.GetSingleProduct(Id);
            if(SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Product = product, Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                int index = isItemExists(Id);
                if(index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Product = product, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }

            return RedirectToAction("Index", "Shop");
        }

        [Route("Remove/{Id}")]
        public IActionResult Remove(int Id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = isItemExists(Id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index", "Shop");

        }


        private int isItemExists(int Id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            for(int i = 0; i < cart.Count; i++)
            {
                if(cart[i].Product?.Id == Id)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
