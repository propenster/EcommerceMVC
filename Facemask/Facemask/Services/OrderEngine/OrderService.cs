using Facemask.DAL.WorkUnits;
using Facemask.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Services.OrderEngine
{
    public class OrderService : IOrderService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger _logger;

        public OrderService(UnitOfWork unitOfWork, ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public void AddManyOrders(IEnumerable<Order> orders)
        {
            try
            {
                _unitOfWork.Orders.AddRange(orders);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(AddManyOrders)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public void AddSingleOrder(Order order)
        {
            try
            {
                _unitOfWork.Orders.Add(order);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(AddSingleOrder)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            IEnumerable<Order> allOrders = null;
            try
            {
                allOrders = _unitOfWork.Orders.GetAll();

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetAllOrders)} ERROR MSG: {ex.Message}");
            }

            return allOrders;
        }

        public IEnumerable<Order> GetOrdersByCount(int Count)
        {
            IEnumerable<Order> ordersByCount = null;
            try
            {
                ordersByCount = _unitOfWork.Orders.GetByCount(Count);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetOrdersByCount)} ERROR MSG: {ex.Message}");
            }

            return ordersByCount;
        }

        public IEnumerable<Order> GetPaginatedOrders(int Page, int Limit)
        {
            IEnumerable<Order> paginatedOrders = null;
            try
            {
                paginatedOrders = _unitOfWork.Orders.GetPaginatedOrders(Page, Limit);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetPaginatedOrders)} ERROR MSG: {ex.Message}");
            }

            return paginatedOrders;
        }

        public Order GetSingleOrder(int Id)
        {
            Order singleOrder = null;
            try
            {
                singleOrder = _unitOfWork.Orders.GetById(Id);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetSingleOrder)} ERROR MSG: {ex.Message}");
            }

            return singleOrder;
        }

        public void RemoveManyOrders(IEnumerable<Order> orders)
        {
            try
            {
                _unitOfWork.Orders.RemoveRange(orders);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(RemoveManyOrders)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public void RemoveSingleOrder(Order order)
        {
            try
            {
                _unitOfWork.Orders.Remove(order);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(RemoveSingleOrder)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                _unitOfWork.Orders.Update(order);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(UpdateOrder)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }
    }
}
