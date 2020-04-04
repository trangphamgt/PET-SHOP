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
    [RoutePrefix("api/postcategory")]
    [Authorize]
    public class PostCategoryController : ApiBaseController
    {
        private IPostCategoryService _postCategoryService;


        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.UpdatePostCategory(postCategoryVm);

                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.Created, category);

                }
                return response;
            });
        }

        [HttpGet]
        public List<PostViewModel> Get()
        {
            try
            {
                List<PostCategory> list = _postCategoryService.GetAll().ToList();

                List<PostViewModel> listPostVm = Mapper.Map<List<PostViewModel>>(list);
                return listPostVm;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }



        }

        [HttpGet]
        public PostViewModel GetDetail(int id)
        {
            try
            {
                PostCategory _postCategory = _postCategoryService.GetById(id);
                PostViewModel postCategoryVM = Mapper.Map<PostViewModel>(_postCategory);
                return postCategoryVM;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }


        }

        [HttpPut]
        public void Update(PostCategoryViewModel postCategoryVm)
        {
            try
            {
                PostCategory postCategory = new PostCategory();
                postCategory.UpdatePostCategory(postCategoryVm);
                _postCategoryService.Update(postCategory);
                _postCategoryService.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        [HttpDelete]
        public PostViewModel Delete(int id)
        {
            try
            {
                PostCategory postCategory = _postCategoryService.Delete(id);
                PostViewModel postCategoryVm = Mapper.Map<PostViewModel>(postCategory);
                _postCategoryService.SaveChanges();
                return postCategoryVm;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public List<PostViewModel> GetAllPostPaging(int pageIndex, int pageSize, int totalRow)
        {
            try
            {
                var lst = _postCategoryService.GetAllPaging(pageIndex, pageSize, totalRow);
                List<PostViewModel> lstVm = Mapper.Map<List<PostViewModel>>(lst);
                return lstVm;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
    }
}
