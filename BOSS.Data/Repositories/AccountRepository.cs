using BOSS.Data.Infrastructure;
using BOSS.Model.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Data.Repositories
{
    public interface IAccountRepository : IRepository<ApplicationUser>
    {
        string GetUserNameByEmail(string email);
    }
    public class AccountRepository : RepositoryBase<ApplicationUser>, IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactor) : base(dbFactor)
        {

        }
        public string GetUserNameByEmail(string email)
        {
            return DbContext.Users.Where(c => c.Email == email).First().UserName;
        }
        
    }
}
