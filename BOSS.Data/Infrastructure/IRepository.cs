using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Update(T entity);
        T Delete(int id);
        T Delete(T entity);
        void DeleteMulti(Expression<Func<T, bool>> where);
        T GetById(int id);
        T GetByCondition(Expression<Func<T, bool>> where, string[] includes = null);
        IEnumerable<T> GetAll(string[] include = null);
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> expression, string[] includes = null);
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 20, string[] includes =null);
        int Count(Expression<Func<T, bool>> where);
        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
