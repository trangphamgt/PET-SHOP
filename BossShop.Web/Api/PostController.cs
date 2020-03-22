using AutoMapper;
using BOSS.Model.Models;
using BOSS.Service;
using BossShop.Web.Infrastructure.Core;
using BossShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BossShop.Web.Api
{
    public class PostController : ApiBaseController
    {
        IPostService _postService;
        public PostController(IErrorService errorService, IPostService postService) : base(errorService)
        {
            this._postService = postService;
        }
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, Post post)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else {
                    var _post = _postService.Add(post);
                    _postService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.Created, _post, Configuration.Formatters.JsonFormatter);

                }
                return response;
            });
        }
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                List<Post> list = _postService.GetAll().ToList();

                List<PostViewModel> listPostVm = Mapper.Map<List<PostViewModel>>(list);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostVm);

                return response;
            });
        }
        [HttpGet]
        public HttpResponseMessage GetDetail(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                Post _post = _postService.GetById(id);
                PostViewModel _postVm = Mapper.Map<PostViewModel>(_post);
                response = request.CreateResponse(HttpStatusCode.Created, _postVm, Configuration.Formatters.JsonFormatter);
                return response;
            });
        }
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, Post post)
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
                    _postService.Update(post);
                    _postService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
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
                    var post = _postService.Delete(id);
                    _postService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
        public HttpResponseMessage GetAllPostPaging(HttpRequestMessage request, int pageIndex, int pageSize, int totalRow)
        {

            return CreateHttpResponse(request, () =>
            {
                
                HttpResponseMessage response = null;
                IEnumerable<Post> lst = _postService.GetAllPaging(pageIndex, pageSize,totalRow);
                response = request.CreateResponse(HttpStatusCode.OK, lst);
                return response;
            });
        }

    }
}
