using Microsoft.Data.Entity;
using Microsoft.Data.Entity.ChangeTracking;
using Microsoft.Data.Entity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext ctx;
        protected readonly DbSet<TEntity> Entities;
        protected readonly Func<TEntity, EntityEntry<TEntity>> ChangeTracker;

        public BaseRepository(DbContext ctx)
        {
            this.ctx = ctx;
            this.Entities = this.ctx.Set<TEntity>();
            this.ChangeTracker = this.ctx.Entry<TEntity>;
        }
        
        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return this.Entities.Where(predicate).ToList();
        }
        public TEntity FindFirstOrDefault(Func<TEntity, bool> predicate)
        {
            return this.Entities.FirstOrDefault(predicate);
        }
        
    }
}
