using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Geek.Blog.Db.Interfaces;
using Microsoft.Data.Entity.ChangeTracking;
using System.Linq.Expressions;
using Microsoft.Data.Entity.Extensions;

namespace Geek.Blog.Db.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        readonly DbContext _ctx;
        protected readonly DbSet<TEntity> Entities;
        protected readonly Func<TEntity, EntityEntry<TEntity>> ChangeTracker;

        public BaseRepository(DbContext ctx)
        {
            this._ctx = ctx;
            this.Entities = this._ctx.Set<TEntity>();
            this.ChangeTracker = _ctx.Entry;
        }

        public TEntity Get(TKey id)
        {
            return this.Entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Entities.Where(predicate);
        }

        public TEntity FindFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Find(predicate).FirstOrDefault();
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