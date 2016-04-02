using Geek.Blog.Db.Interfaces;
using Geek.Blog.Db.UnitOfWork;
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
        public static IUnitOfWork Readonly()
        {
            return GetUnitOfWork<BlogUnitOfWork, BlogContext> ("Readonly");
        }

        public static IUnitOfWork ReadWrite()
        {
            return GetUnitOfWork<BlogUnitOfWork, BlogContext>("ReadWrite");
        }

       
        public static void RecreateDb()
        {
            var s = ConfigurationManager.ConnectionStrings["ReadWrite"].ConnectionString;
            var dbOpts = new DbContextOptionsBuilder();
            dbOpts.UseSqlServer(s);
            using (var db = new BlogContext(dbOpts.Options))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        private static TUnitOfWork GetUnitOfWork<TUnitOfWork, C>(string connectionName) where TUnitOfWork : class, IUnitOfWork where C: BlogContext
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            DbContextOptionsBuilder opts = new DbContextOptionsBuilder();
            opts.UseSqlServer(connectionString);

            var ctx = GetContext<C>();
            if (typeof(TUnitOfWork) == typeof(BlogUnitOfWork))
            {
                return new BlogUnitOfWork(ctx(opts.Options)) as TUnitOfWork;
            }
           
            throw new ArgumentOutOfRangeException("Cannot construct Uow");
        }

        private static Func<DbContextOptions, C> GetContext<C>() where C : BlogContext
        {
            if (typeof(C) == typeof(BlogContext))
            {
                return (opts) => new BlogContext(opts) as C;
            }
           

            throw new ArgumentOutOfRangeException("Cannot construct dbContext");
        }
    }
}
