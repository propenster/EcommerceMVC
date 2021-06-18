using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.DAL.Repositories.ProductRepo
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(FacemaskDbContext context) : base(context)
        {

        }
        public IEnumerable<Product> GetPaginatedProducts(int Page, int Limit)
        {
            return FacemaskDbContext.Products.Skip((Page - 1) * Limit).Take(Limit).ToList();
        }

        public bool ProductExists(int Id)
        {
            return FacemaskDbContext.Products.Any(x => x.Id == Id);
        }

        public Product GetProductBySlug(string Slug)
        {
            return FacemaskDbContext.Products.Where(x => x.Slug == Slug).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductByCategoryId(int CategoryId)
        {
            //return FacemaskDbContext.Products.Where(x => x.CategoryId == CategoryId).ToList();
            return FindByCondition(x => x.CategoryId == CategoryId).ToList();
        }

        public FacemaskDbContext FacemaskDbContext
        {
            get
            {
                return Context;
            }
        }
    }
}
