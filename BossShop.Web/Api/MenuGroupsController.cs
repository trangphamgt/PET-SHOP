using BOSS.Model.Models;
using BOSS.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace BossShop.Web.Api
{
    public class MenuGroupsController : ApiController
    {
        private IMenuGroupService _menuGroupService;

        public MenuGroupsController(IMenuGroupService menuGroupService)
        {
            this._menuGroupService = menuGroupService;
        }

        [HttpPost]
        public MenuGroup Add(MenuGroup model)
        {
            var res = _menuGroupService.Add(model);
            _menuGroupService.SaveChanges();
            return res;
        }
        public MenuGroup Get(int id)
        {
            return _menuGroupService.GetById(id);
        }
        [HttpGet]
        public IEnumerable<MenuGroup> Get()
        {
            return _menuGroupService.GetAll();
        }
        [HttpPut]
        public void Update(int Id, MenuGroup model) {
            _menuGroupService.Update(model);
        }

        [HttpDelete]
        public MenuGroup Delete(int Id)
        {
            var res =  _menuGroupService.Delete(Id);
            _menuGroupService.SaveChanges();
            return res;
        }
    }
}