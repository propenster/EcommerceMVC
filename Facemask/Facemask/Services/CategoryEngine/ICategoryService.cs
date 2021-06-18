using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Services.CategoryEngine
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetPaginatedCategories(int Page, int Limit);
        Category GetSingleProduct(int Id);
        Category GetProductBySlug(string slug);
        void AddSingleProduct(Category category);
        void AddManyCategories(IEnumerable<Category> categories);
        void UpdateCategory(Category category);
        void RemoveSingleCategory(Category category);
        void RemoveManyCategories(IEnumerable<Category> categories);
    }
}
