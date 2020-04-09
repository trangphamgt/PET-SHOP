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
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory model);
        ProductCategory Delete(int id);
        ProductCategory Delete(ProductCategory model);
        ProductCategory GetById(int id);
        void Update(ProductCategory post);
        IEnumerable<ProductCategory> GetAll();
        IEnumerable<ProductCategory> GetAllPaging(int pageIndex, int page, int totalRow);
        void SaveChanges();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository _productCategoryRepository;
        IUnitOfWork _unitofWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitofWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitofWork = unitofWork;
        }
        public ProductCategory Add(ProductCategory model)
        {
            return _productCategoryRepository.Add(model);
        }

        public ProductCategory Delete(int id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public ProductCategory Delete(ProductCategory model)
        {
            return _productCategoryRepository.Delete(model);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllPaging(int pageIndex, int page, int totalRow)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitofWork.Commit();
        }

        public void Update(ProductCategory model)
        {
            _productCategoryRepository.Update(model);
        }
    }

}
