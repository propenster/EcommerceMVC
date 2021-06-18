using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.DAL.Repositories.OrderRepo
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetPaginatedOrders(int Page, int Limit);
        bool OrderExists(int Id);

    }
}
