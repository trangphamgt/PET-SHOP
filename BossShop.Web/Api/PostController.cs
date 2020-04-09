using AutoMapper;
using BOSS.Model.Models;
using BOSS.Service;
using BossShop.Web.Infrastructure.Core;
using BossShop.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BossShop.Web.Infrastructure.Extensions;
using System.Collections;

namespace BossShop.Web.Api
{
    public class PostController : ApiBaseController
    {
        private IPostService _postService;

        public PostController(IPostService postService, IErrorService errorService) : base(errorService)
        {
            this._postService = postService;
        }

        [HttpPost]
        public PostViewModel Add(PostViewModel model)
        {
            try
            {
                Post postCategory = new Post();
                postCategory.UpdatePost(model);

                var res = _postService.Add(postCategory);
                _postService.SaveChanges();
                return Mapper.Map<PostViewModel>(res);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        [HttpGet]
        public PostViewModel Get(int id)
        {
            try
            {
                return Mapper.Map<PostViewModel>(_postService.GetById(id));
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        [HttpGet]
        public IEnumerable<PostViewModel> Get()
        {
            var lst = _postService.GetAll();
            List<PostViewModel> res = Mapper.Map<List<PostViewModel>>(lst);
            return res;
        }
        [HttpPut]
        public void Update(int Id, PostViewModel model)
        {
            try
            {
                Post postCategory = new Post();
                postCategory.UpdatePost(model);
                _postService.Update(postCategory);
                _postService.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError(ex);

            }
        }

        [HttpDelete]
        public PostViewModel Delete(int Id)
        {
            try
            {
                var model = _postService.Delete(Id);
                _postService.SaveChanges();
                var res = Mapper.Map<PostViewModel>(model);
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