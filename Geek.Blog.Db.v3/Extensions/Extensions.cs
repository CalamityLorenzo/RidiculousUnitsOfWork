using Geek.Blog.Posts.DomainModel;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Data.Entity.Extensions
{
    public static class Extensions
    {
        public static TEntity Find<TEntity>(this DbSet<TEntity> set, params object[] keyValues) where TEntity : class
        {
            var context = ((IInfrastructure<IServiceProvider>)set).GetService<DbContext>();

            var entityType = context.Model.FindEntityType(typeof(TEntity));
            var key = entityType.FindPrimaryKey();

            var entries = context.ChangeTracker.Entries<TEntity>();
            var i = 0;
            foreach (var property in key.Properties)
            {
                var idx = i;
                entries = entries.Where(e => e.Property(property.Name).CurrentValue == keyValues[idx]);
                i++;
            }

            var entry = entries.FirstOrDefault();
            if (entry != null)
            {
                // Return the local object if it exists.
                return entry.Entity;
            }


            var keyCompare = key.Properties[0].Name;
            // TODO: Build the real LINQ Expression
            // set.Where(x => x.Id == keyValues[0]);
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var query = set.Where((Expression<Func<TEntity, bool>>)
                Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, keyCompare),
                        //Expression.Property(parameter, "Id"),
                        Expression.Constant(keyValues[0])),
                    parameter));

            // Look in the database
            return query.FirstOrDefault();
        }
    }
}

namespace Geek.Blog.Db.Domain
{
    public static class MapExtensions
    {
        public static CompletePost MapCompletePost(this PostBody @this)
        {
            CompletePost cPost = new CompletePost(@this.PostHeader.Title, @this.PostHeader.Url, "", @this.PostText);
            return cPost;
        }

        public static BlogPostInfo MapPostHeader(this PostHead @this)
        {
            return BlogPostInfo.Empty();
        }
    }
}