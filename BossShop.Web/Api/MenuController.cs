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
        public MenuViewModel Add(MenuViewModel model)
        {
            try
            {
                Menu menu = new Menu();
                menu.UpdateMenu(model);

                var res = _menuService.Add(menu);
                _menuService.SaveChanges();
                return Mapper.Map<MenuViewModel>(res);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
        [HttpGet]
        public MenuViewModel Get(int id)
        {
            try
            {
                return Mapper.Map<MenuViewModel>(_menuService.GetById(id));
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
     
        public IEnumerable<MenuViewModel> GetByAdmin(bool IsAdmin)
        {
            var lst = _menuService.GetAll(IsAdmin);
            List<MenuViewModel> res = Mapper.Map<List<MenuViewModel>>(lst);
            return res;
        }
        public IEnumerable<MenuGroupViewModel> GetAllMenuGroup(bool IsAdmin = false)
        {
            List<MenuGroupViewModel> res = Mapper.Map<List<MenuGroupViewModel>>(_menuService.GetMenuGroup(IsAdmin));
            return res;
        }
        [HttpPut]
        public void Update(int Id, MenuViewModel model)
        {
            try
            {
                Menu menu = new Menu();
                menu.UpdateMenu(model);
                _menuService.Update(menu);
                _menuService.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError(ex);

            }
        }

        [HttpDelete]
        public MenuViewModel Delete(int Id)
        {
            try
            {
                var model = _menuService.Delete(Id);
                _menuService.SaveChanges();
                var res = Mapper.Map<MenuViewModel>(model);
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
