using Geek.Blog.Db.Context;
using Geek.Blog.Db.Interfaces;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.UnitsOfWork
{
    public static class UnitOfWorkFactory
    {
        public static IReadonlyUnitOfWork Readonly()
        {
            return GetUnitOfWork<BlogReadUow, BlogContext> ("Readonly");
        }

        public static IReadWriteUnitOfWork ReadWrite()
        {
            return GetUnitOfWork<BlogReadWriteUow, BlogContext>("ReadWrite");
        }

        public static IReadWriteUnitOfWork DestoryToRecreate()
        {
            return GetUnitOfWork<BlogReadWriteUow, RecreateBlogContext>("ReadWrite");
        }

        private static Uow GetUnitOfWork<Uow, C>(string connectionName) where Uow : class, IUnitOfWork where C: BlogContext
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            DbContextOptionsBuilder opts = new DbContextOptionsBuilder();
            opts.UseSqlServer(connectionString);

            var ctx = GetContext<C>();
            if (typeof(Uow) == typeof(BlogReadUow))
            {
                return new BlogReadUow(ctx(opts.Options)) as Uow;
            }
            if (typeof(Uow) == typeof(BlogReadWriteUow))
            {
                return new BlogReadWriteUow(ctx(opts.Options)) as Uow;
            }

            throw new ArgumentOutOfRangeException("Cannot construct Uow");
        }

        private static Func<DbContextOptions, C> GetContext<C>() where C : BlogContext
        {
            if (typeof(C) == typeof(BlogContext))
            {
                return (opts) => new BlogContext(opts) as C;
            }
            else
            {
                if (typeof(C) == typeof(RecreateBlogContext))
                {
                    return (opts) => new RecreateBlogContext(opts) as C;
                }
            }

            throw new ArgumentOutOfRangeException("Cannot construct dbContext");
        }
    }
}
