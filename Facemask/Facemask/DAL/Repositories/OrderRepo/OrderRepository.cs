using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.DAL.Repositories.OrderRepo
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        //protected readonly FacemaskDbContext Context;
        public OrderRepository(FacemaskDbContext context) : base(context)
        {

        }
        public IEnumerable<Order> GetPaginatedOrders(int Page, int Limit)
        {
            return FacemaskDbContext.Orders.Skip((Page - 1) * Limit).Take(Limit).ToList();
        }

        public bool OrderExists(int Id)
        {
            return FacemaskDbContext.Orders.Any(x => x.Id == Id);
        }

        public FacemaskDbContext FacemaskDbContext
        {
            get { return Context; }
        }
    }
}
