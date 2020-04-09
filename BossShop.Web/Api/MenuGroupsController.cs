using AutoMapper;
using BOSS.Model.Models;
using BOSS.Service;
using BossShop.Web.Infrastructure.Core;
using BossShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using BossShop.Web.Infrastructure.Extensions;
namespace BossShop.Web.Api
{
    public class MenuGroupsController : ApiBaseController
    {
        private IMenuGroupService _menuGroupService;

        public MenuGroupsController(IMenuGroupService menuGroupService, IErrorService errorService) : base(errorService)
        {
            this._menuGroupService = menuGroupService;
        }

        [HttpPost]
        public MenuGroupViewModel Add(MenuGroupViewModel model)
        {
            try
            {
                MenuGroup menuGroup = new MenuGroup();
                menuGroup.UpdateMenuGroup(model);

                var res = _menuGroupService.Add(menuGroup);
                _menuGroupService.SaveChanges();
                return Mapper.Map<MenuGroupViewModel>(res);
            }catch(Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        [HttpGet]
        public MenuGroupViewModel Get(int id)
        {
            try
            {
                return Mapper.Map<MenuGroupViewModel>(_menuGroupService.GetById(id));
            }catch(Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        [HttpGet]
        public IEnumerable<MenuGroupViewModel> Get()
        {
            var lst =  _menuGroupService.GetAll();
            List<MenuGroupViewModel> res = Mapper.Map<List<MenuGroupViewModel>>(lst);
            return res;
        }
        [HttpPut]
        public void Update(int Id, MenuGroupViewModel model) {
            try
            {
                MenuGroup menuGroup = new MenuGroup();
                menuGroup.UpdateMenuGroup(model);
                _menuGroupService.Update(menuGroup);
                _menuGroupService.SaveChanges();
            }catch(Exception ex)
            {
                LogError(ex);
                
            }
        }

        [HttpDelete]
        public MenuGroupViewModel Delete(int Id)
        {
            try
            {
                var model = _menuGroupService.Delete(Id);
                _menuGroupService.SaveChanges();
                var res = Mapper.Map<MenuGroupViewModel>(model);
                return res;
            }catch(Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
    }
}