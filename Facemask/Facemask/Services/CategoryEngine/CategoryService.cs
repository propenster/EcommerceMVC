using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Services.CategoryEngine
{
    public class CategoryService : ICategoryService
    {
        public void AddManyCategories(IEnumerable<Category> categories)
        {
            throw new NotImplementedException();
        }

        public void AddSingleProduct(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetPaginatedCategories(int Page, int Limit)
        {
            throw new NotImplementedException();
        }

        public Category GetProductBySlug(string slug)
        {
            throw new NotImplementedException();
        }

        public Category GetSingleProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public void RemoveManyCategories(IEnumerable<Category> categories)
        {
            throw new NotImplementedException();
        }

        public void RemoveSingleCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
