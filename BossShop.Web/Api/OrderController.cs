using AutoMapper;
using BOSS.Model.Models;
using BOSS.Service;
using BossShop.Web.Infrastructure.Core;
using BossShop.Web.Infrastructure.Extensions;
using BossShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BossShop.Web.Api
{
    public class OrderController : ApiBaseController
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService, IErrorService errorService): base(errorService)
        {
            this._orderService = orderService;
        }
        [HttpPost]
        public OrderViewModel Add(OrderViewModel model)
        {
            try
            {
                Order order = new Order();
                order.UpdateOrder(model);

                var res = _orderService.Add(order);
                _orderService.SaveChanges();
                return Mapper.Map<OrderViewModel>(res);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        [HttpGet]
        public OrderViewModel Get(int id)
        {
            try
            {
                return Mapper.Map<OrderViewModel>(_orderService.GetById(id));
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        [HttpGet]
        public IEnumerable<OrderViewModel> Get()
        {
            var lst = _orderService.GetAll();
            List<OrderViewModel> res = Mapper.Map<List<OrderViewModel>>(lst);
            return res;
        }
        [HttpGet]
        [Route("GetDetail")]
        public OrderDetailViewModel GetDetail(int id)
        {
            var lst = _orderService.GetDetailOrder(id);
            OrderDetailViewModel res = Mapper.Map<OrderDetailViewModel>(lst);
            return res;
        }

        [HttpPut]
        public void Update(int Id, OrderViewModel model)
        {
            try
            {
                Order order = new Order();
                order.UpdateOrder(model);
                _orderService.Update(order);
                _orderService.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError(ex);

            }
        }

        [HttpDelete]
        public OrderViewModel Delete(int Id)
        {
            try
            {
                var model = _orderService.Delete(Id);
                _orderService.SaveChanges();
                var res = Mapper.Map<OrderViewModel>(model);
                return res;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
    }
}
