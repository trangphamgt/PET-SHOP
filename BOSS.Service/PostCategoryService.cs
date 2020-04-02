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
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory post);
        PostCategory Delete(int id);
        PostCategory Delete(PostCategory post);
        PostCategory GetById(int id);
        void Update(PostCategory post);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllPaging(int pageIndex, int page, int totalRow);
        void SaveChanges();

    }
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly IUnitofWork _unitOfWork;
        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitofWork unitofWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitofWork;
        }
        public PostCategory Add(PostCategory model)
        {
           return _postCategoryRepository.Add(model);
        }

        public PostCategory Delete(int id)
        {
            return _postCategoryRepository.Delete(id);
        }

        public PostCategory Delete(PostCategory model)
        {
            return _postCategoryRepository.Delete(model);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }



        public IEnumerable<PostCategory> GetAllPaging(int pageIndex, int page, int totalRow)
        {
            return _postCategoryRepository.GetMultiPaging(c => c.Status == 1,out totalRow, pageIndex, page);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory post)
        {
            _postCategoryRepository.Update(post);
        }
    }
}
