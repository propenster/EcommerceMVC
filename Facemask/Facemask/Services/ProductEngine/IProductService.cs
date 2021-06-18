using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Services.ProductEngine
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetPaginatedProducts(int Page, int Limit);
        IEnumerable<Product> GetProductByCategoryId(int CategoryId);
        IEnumerable<Product> GetProductsByCount(int Count);
        Product GetSingleProduct(int Id);
        Product GetProductBySlug(string slug);
        void AddSingleProduct(Product product);
        void AddManyProducts(IEnumerable<Product> products);
        void UpdateProduct(Product product);
        void RemoveSingleProduct(Product product);
        void RemoveManyProducts(IEnumerable<Product> products);
        

    }
}
