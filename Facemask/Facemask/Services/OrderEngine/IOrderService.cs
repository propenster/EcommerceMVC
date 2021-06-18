using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Services.OrderEngine
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetPaginatedOrders(int Page, int Limit);
        IEnumerable<Order> GetOrdersByCount(int Count);
        Product GetSingleOrder(int Id);
        void AddSingleOrder(Order order);
        void AddManyOrders(IEnumerable<Order> orders);
        void UpdateOrder(Order order);
        void RemoveSingleOrder(Order order);
        void RemoveManyOrders(IEnumerable<Order> orders);
    }
}
