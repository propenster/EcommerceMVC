using Facemask.DAL.Repositories.CategoryRepo;
using Facemask.DAL.Repositories.OrderDetailRepo;
using Facemask.DAL.Repositories.OrderRepo;
using Facemask.DAL.Repositories.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.DAL.WorkUnits
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FacemaskDbContext _context;
        public UnitOfWork(FacemaskDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            Orders = new OrderRepository(_context);
            OrderDetails = new OrderDetailRepository(_context);
            Products = new ProductRepository(_context);
        }
        public ICategoryRepository Categories { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IOrderDetailRepository OrderDetails { get; private set; }

        public IProductRepository Products { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
