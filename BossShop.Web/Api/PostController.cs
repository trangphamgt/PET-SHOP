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
        

        public PostController(IErrorService errorService, IPostService postService) : base(errorService)
        {
            this._postService = postService;
        }

        [HttpPost]
        public PostViewModel Create(PostViewModel postVm)
        {
            try
            {
                Post post = new Post();
                post.UpdatePost(postVm);
                var result = _postService.Add(post);
                _postService.SaveChanges();
                postVm = Mapper.Map<PostViewModel>(result);
                return postVm;
            }catch(Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        [HttpGet]
        public   List<PostViewModel> Get()
        {
            try
            {
                List<Post> list = _postService.GetAll().ToList();

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
                Post _post = _postService.GetById(id);
                PostViewModel postVM = Mapper.Map<PostViewModel>(_post);
                return postVM;
            } catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
            
            
        }

        [HttpPut]
        public void Update(PostViewModel postVm)
        {
            try
            {
                Post post = new Post();
                post.UpdatePost(postVm);
                _postService.Update(post);
                _postService.SaveChanges();
            }catch( Exception ex)
            {
                LogError(ex);
            }
        }

        [HttpDelete]
        public PostViewModel Delete( int id)
        {
            try
            {
                Post post = _postService.Delete(id);
                PostViewModel postVm = Mapper.Map<PostViewModel>(post);
                _postService.SaveChanges();
                return postVm;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public async Task<dynamic> GetAllPostPaging(int pageIndex, int pageSize, int totalRow)
        {
            try
            {
                var lst = _postService.GetAllPaging(pageIndex, pageSize,out totalRow);
                List<PostViewModel> lstVm = Mapper.Map<List<PostViewModel>>(lst);
                var res = new
                {
                    ListPost =  lstVm,
                    totalRow = totalRow
                };
                return res;
            }catch(Exception ex)
            {
                LogError(ex);
                return null;
            }
            
        }
    }
}