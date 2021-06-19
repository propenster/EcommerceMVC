using Facemask.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.DAL
{
    public class FacemaskDbContext : IdentityDbContext
    {

        public FacemaskDbContext(DbContextOptions<FacemaskDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        //public DbSet<User> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasMany<Product>().WithOne().HasForeignKey(p => p.CategoryId);
            builder.Entity<OrderDetail>().HasOne(p => p.Product).WithOne();
            builder.Entity<OrderDetail>().HasOne(p => p.Order).WithOne();
            //builder.Entity<User>().HasMany<Order>().WithOne();
        }
    }
}
