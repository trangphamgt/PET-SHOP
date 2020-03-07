using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BossDbContext dbContext;
        public BossDbContext Init()
        {
            return this.dbContext ?? (dbContext = new BossDbContext());
        }
        protected override void DisposeCore()
        {
            if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }

    }

}
