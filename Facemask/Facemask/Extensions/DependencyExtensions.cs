using Facemask.DAL.Repositories.CategoryRepo;
using Facemask.DAL.Repositories.OrderDetailRepo;
using Facemask.DAL.Repositories.OrderRepo;
using Facemask.DAL.Repositories.ProductRepo;
using Facemask.DAL.WorkUnits;
using Facemask.Services.CategoryEngine;
using Facemask.Services.OrderDetailEngine;
using Facemask.Services.OrderEngine;
using Facemask.Services.ProductEngine;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Extensions
{
    public static class DependencyExtensions
    {


        public static IServiceCollection ConfigureDI(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();


            return services;
        }
    }
}
