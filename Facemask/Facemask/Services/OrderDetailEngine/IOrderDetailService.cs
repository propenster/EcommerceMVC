using Facemask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Services.OrderDetailEngine
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAllOrderDetails();
        IEnumerable<OrderDetail> GetPaginatedOrderDetails(int Page, int Limit);
        IEnumerable<OrderDetail> GetOrderDetailsByCount(int Count);
        OrderDetail GetSingleOrderDetail(int Id);
        void AddSingleOrderDetail(OrderDetail orderDetail);
        void AddManyOrderDetails(IEnumerable<OrderDetail> orderDetails);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void RemoveSingleOrderDetail(OrderDetail orderDetail);
        void RemoveManyOrderDetails(IEnumerable<OrderDetail> orderDetails);
    }
}
