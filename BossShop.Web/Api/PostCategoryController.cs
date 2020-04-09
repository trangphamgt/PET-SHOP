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
using BossShop.Web.Infrastructure.Extensions;
namespace BossShop.Web.Api
{
    public class PostCategoryController : ApiBaseController
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IPostCategoryService postCategoryService, IErrorService errorService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [HttpPost]
        public PostCategoryViewModel Add(PostCategoryViewModel model)
        {
            try
            {
                PostCategory postCategory = new PostCategory();
                postCategory.UpdatePostCategory(model);

                var res = _postCategoryService.Add(postCategory);
                _postCategoryService.SaveChanges();
                return Mapper.Map<PostCategoryViewModel>(res);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        [HttpGet]
        public PostCategoryViewModel Get(int id)
        {
            try
            {
                return Mapper.Map<PostCategoryViewModel>(_postCategoryService.GetById(id));
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        [HttpGet]
        public IEnumerable<PostCategoryViewModel> Get()
        {
            var lst = _postCategoryService.GetAll();
            List<PostCategoryViewModel> res = Mapper.Map<List<PostCategoryViewModel>>(lst);
            return res;
        }
        [HttpPut]
        public void Update(int Id, PostCategoryViewModel model)
        {
            try
            {
                PostCategory postCategory = new PostCategory();
                postCategory.UpdatePostCategory(model);
                _postCategoryService.Update(postCategory);
                _postCategoryService.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError(ex);

            }
        }

        [HttpDelete]
        public PostCategoryViewModel Delete(int Id)
        {
            try
            {
                var model = _postCategoryService.Delete(Id);
                _postCategoryService.SaveChanges();
                var res = Mapper.Map<PostCategoryViewModel>(model);
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
