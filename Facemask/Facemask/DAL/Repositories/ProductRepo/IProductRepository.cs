using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.DAL.Repositories.ProductRepo
{
    public interface IProductRepository : IRepository<Product>
    {


        IEnumerable<Product> GetPaginatedProducts(int Page, int Limit);
        IEnumerable<Product> GetProductByCategoryId(int CategoryId);
        Product GetProductBySlug(string Slug);
        bool ProductExists(int Id);
    }
}
