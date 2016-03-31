using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Geek.Blog.Db.Interfaces;

namespace Geek.Blog.Db.Repositories
{
    public abstract class BaseReadWriteRepository<TEntity, TKey> : BaseReadRepository<TEntity, TKey>, IWriteRepository<TEntity, TKey> where TEntity : class
    {
        public BaseReadWriteRepository(DbContext ctx) : base(ctx)
        {
        }

        public void Add(TEntity entity)
        {
            this.Entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.Entities.AddRange(entities);
        }

        public void Remove(TKey key)
        {
            var toRemove = this.Get(key);
            if(toRemove == null)
            {
                throw new ArgumentNullException($"Can't find {typeof(TEntity).ToString()} matching key : {key}");
            }
            Remove(toRemove);
        }

        public void Remove(TEntity entity)
        {
            this.Entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TKey> keys)
        {
            foreach(var key in keys)
            {
                Remove(key);
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Entities.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            ChangeTracker(entity).State = EntityState.Modified;
        }
    }
}