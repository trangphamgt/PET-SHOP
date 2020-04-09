using BOSS.Model.Models;
using BOSS.Service;
using BossShop.Web.Infrastructure.Core;
using BossShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BossShop.Web.Infrastructure.Extensions;
using AutoMapper;

namespace BossShop.Web.Api
{
    public class ProductCategoryController : ApiBaseController
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService, IErrorService errorService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [HttpPost]
        public ProductCategoryViewModel Add(ProductCategoryViewModel model)
        {
            try
            {
                ProductCategory productCategory = new ProductCategory();
                productCategory.UpdateProductCategory(model);

                var res = _productCategoryService.Add(productCategory);
                _productCategoryService.SaveChanges();
                return Mapper.Map<ProductCategoryViewModel>(res);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        [HttpGet]
        public ProductCategoryViewModel Get(int id)
        {
            try
            {
                return Mapper.Map<ProductCategoryViewModel>(_productCategoryService.GetById(id));
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        [HttpGet]
        public IEnumerable<ProductCategoryViewModel> Get()
        {
            var lst = _productCategoryService.GetAll();
            List<ProductCategoryViewModel> res = Mapper.Map<List<ProductCategoryViewModel>>(lst);
            return res;
        }
        [HttpPut]
        public void Update(int Id, ProductCategoryViewModel model)
        {
            try
            {
                ProductCategory productCategory = new ProductCategory();
                productCategory.UpdateProductCategory(model);
                _productCategoryService.Update(productCategory);
                _productCategoryService.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError(ex);

            }
        }

        [HttpDelete]
        public ProductCategoryViewModel Delete(int Id)
        {
            try
            {
                var model = _productCategoryService.Delete(Id);
                _productCategoryService.SaveChanges();
                var res = Mapper.Map<ProductCategoryViewModel>(model);
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
