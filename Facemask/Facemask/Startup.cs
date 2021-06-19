using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facemask.DAL;
using Facemask.DAL.Repositories.CategoryRepo;
using Facemask.DAL.Repositories.OrderDetailRepo;
using Facemask.DAL.Repositories.OrderRepo;
using Facemask.DAL.Repositories.ProductRepo;
using Facemask.DAL.WorkUnits;
using Facemask.Extensions;
using Facemask.Models;
using Facemask.Services.CategoryEngine;
using Facemask.Services.OrderDetailEngine;
using Facemask.Services.OrderEngine;
using Facemask.Services.ProductEngine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Facemask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<FacemaskDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContextPool<FacemaskDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("SqliteDbConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<ICategoryService, CategoryService>();
            //services.AddTransient<IOrderService, OrderService>();
            //services.AddTransient<IOrderDetailService, OrderDetailService>();
            //services.AddTransient<IProductService, ProductService>();
            //services.AddTransient<ICategoryRepository, CategoryRepository>();
            //services.AddTransient<IOrderRepository, OrderRepository>();
            //services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            //services.AddTransient<IProductRepository, ProductRepository>();

            services.AddIdentity<User, Role>(config =>
            {
                config.Password.RequiredLength = 10;
                config.Password.RequiredUniqueChars = 3;
                config.Lockout.MaxFailedAccessAttempts = 5;
            }).AddEntityFrameworkStores<FacemaskDbContext>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ///services.ConfigureDI();
            services.AddControllersWithViews();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Home}/{action=Index}/{id?}");
                    pattern: "{controller=Shop}/{action=Index}/{id?}");

            });
        }
    }
}
