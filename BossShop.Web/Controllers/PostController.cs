using BOSS.Model.Models;
using BOSS.Service;
using BossShop.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BossShop.Web.Controllers
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
                HttpResponseMessage response = null;
                IEnumerable<Post> _post = _postService.GetAll().ToList();
                response = request.CreateResponse(HttpStatusCode.Created, _post, Configuration.Formatters.JsonFormatter);
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
                response = request.CreateResponse(HttpStatusCode.Created, _post, Configuration.Formatters.JsonFormatter);
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
                    _postService.Delete(id);
                    _postService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
        public HttpRequestMessage GetAllPostPaging(HttpRequestMessage request, int pageIndex, int pageSize)
        {
            int totalRow = 0;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                IEnumerable<Post> lst = _postService.GetAllPaging(pageIndex, pageSize, totalRow);
                response = request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
        }

    }
}
