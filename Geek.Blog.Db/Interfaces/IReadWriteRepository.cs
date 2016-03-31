using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Interfaces
{
    public interface IReadWriteRepository<TEntity, UKeyType> : IReadonlyRepository<TEntity, UKeyType> where TEntity : class
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
