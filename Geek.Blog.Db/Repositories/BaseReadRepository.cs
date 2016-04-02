using Geek.Blog.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Extensions;
using Microsoft.Data.Entity.ChangeTracking;

namespace Geek.Blog.Db.Repositories
{
    public abstract class BaseReadRepository<TEntity, TKeyType> : IReadonlyRepository<TEntity, TKeyType> where TEntity : class
    {
        readonly DbContext _ctx;
        protected readonly DbSet<TEntity> Entities;
        protected readonly Func<TEntity, EntityEntry<TEntity>> ChangeTracker;

        public BaseReadRepository(DbContext ctx)
        {
            this._ctx = ctx;
            this.Entities = this._ctx.Set<TEntity>();
            this.ChangeTracker = _ctx.Entry;
        }

        public TEntity Get(TKeyType id)
        {
            return this.Entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Entities.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Entities.Where(predicate);
        }

        public TEntity FindFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Find(predicate).FirstOrDefault();
        }

    }
}
