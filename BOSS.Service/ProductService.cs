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
    public interface IProductService
    {
        Product Add(Product model);
        Product Delete(int id);
        Product Delete(Product model);
        Product GetById(int id);
        void Update(Product model);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllPaging(int pageIndex, int page, int totalRow);
        void SaveChanges();
    }
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitofWork;

        public ProductService(IProductRepository productCategoryRepository, IUnitOfWork unitofWork)
        {
            this._productRepository = productCategoryRepository;
            this._unitofWork = unitofWork;
        }
        public Product Add(Product model)
        {
            return _productRepository.Add(model);
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public Product Delete(Product model)
        {
            return _productRepository.Delete(model);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAllPaging(int pageIndex, int page, int totalRow)
        {
            return _productRepository.GetMultiPaging(x => x.Status != 0, out totalRow, pageIndex, page);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitofWork.Commit();
        }

        public void Update(Product model)
        {
            _productRepository.Update(model);
        }
    }
}
