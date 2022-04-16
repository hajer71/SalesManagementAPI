using API.Common.DTO;
using DataAccess.SQLServer.Repository;
using SalesAPI.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Domain.Entities
{
    public class OrderEntity : IOrderEntity
    {
        #region PRIVATE PROPERTIES

        private readonly IOrderRepository _orderRepository;

        #endregion

        #region CONSTRUCTOR

        public OrderEntity(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        #endregion

        #region METHODS
        public List<Order> getListofAllOrders()
        {
            try
            {
                return _orderRepository.getListofAllOrders();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Order GetOrderById2(int id)
        {
            try
            {
                return _orderRepository.GetOrderById2(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddOrder(Order OR)
        {
            try
            {
                _orderRepository.AddOrder(OR);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateOrder(Order OR)
        {
            try
            {
                _orderRepository.UpdateOrder(OR);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteOrder(int id)
        {
            try
            {
                _orderRepository.DeleteOrder(id);

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }

}