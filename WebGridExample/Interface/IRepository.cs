using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebGridExample.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int Count(Expression<Func<TEntity, bool>> predicate);
        int Add(TEntity entity);
        int SaveChanges();
        int Delete(TEntity entity);
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        void Dispose();

    }
}