using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.DAL.Repositories.OrderDetailRepo
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {

        public OrderDetailRepository(FacemaskDbContext context) : base(context)
        {

        }

        public IEnumerable<OrderDetail> GetPaginatedOrderDetails(int Page, int Limit)
        {
            return FacemaskDbContext.OrderDetails.Skip((Page - 1) * Limit).Take(Limit).ToList();
        }

        public FacemaskDbContext FacemaskDbContext
        {
            get { return Context; }
        }
    }
}
