using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Data.Infrastructure
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly IDbFactory dbFactory;
        private BossDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public BossDbContext DbContext
        {
            get { return dbContext ??( dbContext = dbFactory.Init()); }
        }
        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
