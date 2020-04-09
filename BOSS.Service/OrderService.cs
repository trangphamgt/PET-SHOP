using BOSS.Data.Infrastructure;
using BOSS.Data.Repositories;
using BOSS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Service
{
    public interface IOrderService
    {
        Order Add(Order model);
        Order Delete(int id);
        Order Delete(Order model);
        OrderDetail GetDetailOrder(int id);
        Order GetById(int id);
        void Update(Order model);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetAllPaging(int pageIndex, int page, int totalRow);
        void SaveChanges();
    }
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IOrderDetailRepository _orderDetailRepository;
        IUnitOfWork _unitofWork;

        public OrderService(IOrderRepository orderRepository,IOrderDetailRepository orderDetailRepository, IUnitOfWork unitofWork)
        {
            this._orderDetailRepository = orderDetailRepository;
            this._orderRepository = orderRepository;
            this._unitofWork = unitofWork;
        }
        public Order Add(Order model)
        {
            return _orderRepository.Add(model);
        }

        public Order Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public Order Delete(Order model)
        {
            return _orderRepository.Delete(model);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public IEnumerable<Order> GetAllPaging(int pageIndex, int page, int totalRow)
        {
            return _orderRepository.GetMultiPaging(x => x.Status, out totalRow, pageIndex, page);
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }
        public OrderDetail GetDetailOrder(int id)
        {
            return _orderDetailRepository.GetById(id);
        }
        public void SaveChanges()
        {
            _unitofWork.Commit();
        }

        public void Update(Order model)
        {
            _orderRepository.Update(model);
        }
    }
}
