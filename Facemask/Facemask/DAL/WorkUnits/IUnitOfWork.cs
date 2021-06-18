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
    public interface IUnitOfWork : IDisposable
    {

        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }
        IProductRepository Products { get; }

        int Commit();
    }
}
