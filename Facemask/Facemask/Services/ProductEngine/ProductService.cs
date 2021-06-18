using Facemask.DAL.WorkUnits;
using Facemask.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Services.ProductEngine
{
    public class ProductService : IProductService
    {

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger _logger;

        public ProductService(UnitOfWork unitOfWork, ILogger<ProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public void AddManyProducts(IEnumerable<Product> products)
        {
            try
            {
                _unitOfWork.Products.AddRange(products);
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED IN ADDING PRODUCTs TO DB {nameof(AddManyProducts)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public void AddSingleProduct(Product product)
        {
            try
            {
                _unitOfWork.Products.Add(product);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED IN ADDING PRODUCT TO DB {nameof(AddSingleProduct)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> allProducts = null;
            try
            {
                allProducts = _unitOfWork.Products.GetAll();

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetAllProducts)} ERROR MSG: {ex.Message}");
            }

            return allProducts;

        }

        public IEnumerable<Product> GetPaginatedProducts(int Page, int Limit)
        {
            IEnumerable<Product> paginatedProducts = null;
            try
            {
                paginatedProducts = _unitOfWork.Products.GetPaginatedProducts(Page, Limit);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetPaginatedProducts)} ERROR MSG: {ex.Message}");
            }

            return paginatedProducts;
        }

        public IEnumerable<Product> GetProductByCategoryId(int CategoryId)
        {
            IEnumerable<Product> productsByCategoryId = null;
            try
            {
                productsByCategoryId = _unitOfWork.Products.GetProductByCategoryId(CategoryId);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetProductByCategoryId)} ERROR MSG: {ex.Message}");
            }

            return productsByCategoryId;
        }

        public Product GetProductBySlug(string slug)
        {
            Product productBySlug = null;
            try
            {
                productBySlug = _unitOfWork.Products.GetProductBySlug(slug);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetProductBySlug)} ERROR MSG: {ex.Message}");
            }

            return productBySlug;
        }

        public IEnumerable<Product> GetProductsByCount(int Count)
        {
            IEnumerable<Product> productsByCount = null;
            try
            {
                productsByCount = _unitOfWork.Products.GetByCount(Count);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetProductsByCount)} ERROR MSG: {ex.Message}");
            }

            return productsByCount;
        }

        public Product GetSingleProduct(int Id)
        {
            Product singleProduct = null;
            try
            {
                singleProduct = _unitOfWork.Products.GetById(Id);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetSingleProduct)} ERROR MSG: {ex.Message}");
            }

            return singleProduct;
        }

        public void RemoveManyProducts(IEnumerable<Product> products)
        {
            try
            {
                _unitOfWork.Products.RemoveRange(products);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(RemoveManyProducts)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public void RemoveSingleProduct(Product product)
        {
            try
            {
                _unitOfWork.Products.Remove(product);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(RemoveSingleProduct)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                _unitOfWork.Products.Update(product);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(UpdateProduct)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }
    }
}
