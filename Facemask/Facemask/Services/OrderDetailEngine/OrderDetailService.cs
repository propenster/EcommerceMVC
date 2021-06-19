using Facemask.DAL.WorkUnits;
using Facemask.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Services.OrderDetailEngine
{
    public class OrderDetailService : IOrderDetailService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger _logger;

        public OrderDetailService(UnitOfWork unitOfWork, ILogger<OrderDetailService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public void AddManyOrderDetails(IEnumerable<OrderDetail> orderDetails)
        {
            try
            {
                _unitOfWork.OrderDetails.AddRange(orderDetails);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(AddManyOrderDetails)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public void AddSingleOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _unitOfWork.OrderDetails.Add(orderDetail);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(AddSingleOrderDetail)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            IEnumerable<OrderDetail> allOrderDetails = null;
            try
            {
                allOrderDetails = _unitOfWork.OrderDetails.GetAll();

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetAllOrderDetails)} ERROR MSG: {ex.Message}");
            }

            return allOrderDetails;
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByCount(int Count)
        {
            IEnumerable<OrderDetail> orderDetailsByCount = null;
            try
            {
                orderDetailsByCount = _unitOfWork.OrderDetails.GetByCount(Count);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetOrderDetailsByCount)} ERROR MSG: {ex.Message}");
            }

            return orderDetailsByCount;
        }

        public IEnumerable<OrderDetail> GetPaginatedOrderDetails(int Page, int Limit)
        {
            IEnumerable<OrderDetail> paginatedOrderDetails = null;
            try
            {
                paginatedOrderDetails = _unitOfWork.OrderDetails.GetPaginatedOrderDetails(Page, Limit);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetPaginatedOrderDetails)} ERROR MSG: {ex.Message}");
            }

            return paginatedOrderDetails;
        }

        public OrderDetail GetSingleOrderDetail(int Id)
        {
            OrderDetail singleOrderDetail = null;
            try
            {
                singleOrderDetail = _unitOfWork.OrderDetails.GetById(Id);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(GetSingleOrderDetail)} ERROR MSG: {ex.Message}");
            }

            return singleOrderDetail;
        }

        public void RemoveManyOrderDetails(IEnumerable<OrderDetail> orderDetails)
        {
            try
            {
                _unitOfWork.OrderDetails.RemoveRange(orderDetails);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(RemoveManyOrderDetails)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public void RemoveSingleOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _unitOfWork.OrderDetails.Remove(orderDetail);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(RemoveSingleOrderDetail)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _unitOfWork.OrderDetails.Update(orderDetail);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR OCCURRED METHOD: {nameof(UpdateOrderDetail)} ERROR MSG: {ex.Message}");
                _unitOfWork.Dispose();
            }

            _unitOfWork.Commit();
        }
    }
}
