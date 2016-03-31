using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Interfaces
{
    public interface IReadonlyRepository<TEntity, UKeyType> where TEntity : class
    {
        TEntity Get(UKeyType id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindFirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IWriteRepository<TEntity, UKeyType> : IReadonlyRepository<TEntity, UKeyType> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Remove(UKeyType key);
        void RemoveRange(IEnumerable<UKeyType> keys);
        void Update(TEntity entity);
    }
}
