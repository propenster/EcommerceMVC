using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Facemask.DAL.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByCount(int Count);
        T GetById(int Id);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entites);

        
    }
}
