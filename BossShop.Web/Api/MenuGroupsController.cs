using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BOSS.Data;
using BOSS.Model.Models;
using BOSS.Service;
using BossShop.Web.Infrastructure.Core;

namespace BossShop.Web.Api
{
    public class MenuGroupsController : ApiBaseController
    {
        private IMenuGroupService _menuGroupService;
        public MenuGroupsController(IErrorService errorService, IMenuGroupService menuGroupService) : base(errorService)
        {
            this._menuGroupService = menuGroupService;
        }


        // GET: api/MenuGroups
        public IEnumerable<MenuGroup> GetMenuGroups()
        {
            return _menuGroupService.GetAll();
        }

        // GET: api/MenuGroups/5
        [ResponseType(typeof(MenuGroup))]
        //public async Task<IHttpActionResult> GetMenuGroup(int id)
        //{
        //    MenuGroup menuGroup = await db.MenuGroups.FindAsync(id);
        //    if (menuGroup == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(menuGroup);
        //}

        // PUT: api/MenuGroups/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutMenuGroup(int id, MenuGroup menuGroup)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != menuGroup.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(menuGroup).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MenuGroupExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/MenuGroups
        [ResponseType(typeof(MenuGroup))]
        [HttpPost]
        public MenuGroup PostMenuGroup(MenuGroup menuGroup)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.MenuGroups.Add(menuGroup);
            //await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = menuGroup.Id }, menuGroup);
            if (!ModelState.IsValid)
            {
                return null;
            }
            MenuGroup res = _menuGroupService.Add(menuGroup);
            _menuGroupService.SaveChanges();
            return res;
            
        }

        // DELETE: api/MenuGroups/5
        //[ResponseType(typeof(MenuGroup))]
        //public async Task<IHttpActionResult> DeleteMenuGroup(int id)
        //{
        //    MenuGroup menuGroup = await db.MenuGroups.FindAsync(id);
        //    if (menuGroup == null)
        //    {
        //        return NotFound();
        //    }

        //    db.MenuGroups.Remove(menuGroup);
        //    await db.SaveChangesAsync();

        //    return Ok(menuGroup);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool MenuGroupExists(int id)
        //{
        //    return db.MenuGroups.Count(e => e.Id == id) > 0;
        //}
    }
}