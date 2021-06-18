using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Facemask.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly FacemaskDbContext Context;

        public Repository(FacemaskDbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition)
        {
            return Context.Set<T>().Where(condition).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public IEnumerable<T> GetByCount(int Count)
        {
            return Context.Set<T>().Take(Count).ToList();
        }

        public T GetById(int Id)
        {
            return Context.Set<T>().Find(Id);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entites)
        {
            Context.Set<T>().RemoveRange(entites);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
