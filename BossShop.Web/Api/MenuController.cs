using BOSS.Service;
using BossShop.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BossShop.Web.Infrastructure.Extensions;
using BOSS.Model.Models;
using AutoMapper;
using BossShop.Web.Models;
using BossShop.Web.Models.Response;
using BOSS.Common;

namespace BossShop.Web.Api
{
    public class MenuController : ApiBaseController
    {
        private IMenuService _menuService;
        public MenuController(IMenuService menuService, IErrorService errorService) : base(errorService)
        {
            this._menuService = menuService;
        }

        [HttpPost]
        public ApiResponse<MenuViewModel> Add(MenuViewModel model)
        {
           try
            {
                Menu menu = new Menu();
                menu.UpdateMenu(model);
                var result = _menuService.Add(menu);
                _menuService.SaveChanges();
                return new ApiResponse<MenuViewModel>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Result = Mapper.Map<MenuViewModel>(result),
                };
            }catch(Exception ex)
            {
                LogError(ex);
                return new ApiResponse<MenuViewModel>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    IsError = true
                };
            }
        }
        [HttpGet]
        public ApiResponse<MenuViewModel> Get(int id)
        {
            try
            {
                var result = Mapper.Map<MenuViewModel>(_menuService.GetById(id));
                return new ApiResponse<MenuViewModel>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Result = result
                };
            }
            catch (Exception ex)
            {
                LogError(ex);
                return new ApiResponse<MenuViewModel>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    IsError = true,
                    Message = ex.InnerException.Message
                };
            }
        }

        public QueryListResponse< MenuViewModel > GetMenuByRole(int role)
        {
            IEnumerable<MenuViewModel> result = null;
            if(role != (int)RoleEnum.Both)
            {
                result = Mapper.Map<IEnumerable<MenuViewModel>>(_menuService.GetMenuByRole(role));
            }
            else
            {
                result = Mapper.Map<IEnumerable<MenuViewModel>>(_menuService.GetMenus());
            }
            return new QueryListResponse<MenuViewModel>
            {
                Count = result.Count(),
                Items = result
            };
        }


        [HttpPut]
        public ApiResponse< MenuViewModel > Update(int Id, MenuViewModel model)
        {
            try
            {
                Menu menu = new Menu();
                menu.UpdateMenu(model);
                _menuService.Update(menu);
                _menuService.SaveChanges();
                return new ApiResponse<MenuViewModel>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    IsError = false
                };
            }
            catch (Exception ex)
            {
                LogError(ex);
                return new ApiResponse<MenuViewModel>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    IsError = true
                };
            }
        }

        [HttpDelete]
        public ApiResponse< MenuViewModel > Delete(int Id)
        {
            try
            {
                var model = _menuService.Delete(Id);
                _menuService.SaveChanges();
                var res = Mapper.Map<MenuViewModel>(model);
                return new ApiResponse<MenuViewModel>
                {
                    Result = res,
                    IsError = false,
                    StatusCode = (int)HttpStatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                LogError(ex);
                return new ApiResponse<MenuViewModel>
                {
                    IsError = true,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };
            }
        }
    }
}
