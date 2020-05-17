using BOSS.Data.Infrastructure;
using BOSS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Data.Repositories
{
    public interface IMenuRepository: IRepository<Menu>
    {
        IEnumerable<Menu> GetMenuWithRole(int role);
    }
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Menu> GetMenuWithRole(int role)
        {
            var query = from m in DbContext.Menus
                        join mg in DbContext.MenuGroups
                        on m.GroupId equals mg.Id
                        where mg.UserRole == role
                        select m;
            return query.ToList();
        }
    }
}
