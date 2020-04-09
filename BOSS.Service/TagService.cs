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
    public interface ITagService
    {
        Tag Add(Tag model);
        Tag Delete(int id);
        Tag Delete(Tag model);
        Tag GetById(int id);
        void Update(Tag model);
        IEnumerable<Tag> GetAll();
        IEnumerable<Tag> GetAllPaging(int pageIndex, int page, int totalRow);
        void SaveChanges();
    }
    public class TagService : ITagService
    {
        ITagRepository _orderRepository;
        IUnitOfWork _unitofWork;

        public TagService(ITagRepository tagRepository, IUnitOfWork unitofWork)
        {
            this._orderRepository = tagRepository;
            this._unitofWork = unitofWork;
        }
        public Tag Add(Tag model)
        {
            return _orderRepository.Add(model);
        }

        public Tag Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public Tag Delete(Tag model)
        {
            return _orderRepository.Delete(model);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public IEnumerable<Tag> GetAllPaging(int pageIndex, int page, int totalRow)
        {
            return _orderRepository.GetMultiPaging( null , out totalRow, pageIndex, page);
        }

        public Tag GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitofWork.Commit();
        }

        public void Update(Tag model)
        {
            _orderRepository.Update(model);
        }
    }
}
