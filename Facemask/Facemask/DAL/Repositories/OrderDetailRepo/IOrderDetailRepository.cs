using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.DAL.Repositories.OrderDetailRepo
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {

        IEnumerable<OrderDetail> GetPaginatedOrderDetails(int Page, int Limit);

    }
}
