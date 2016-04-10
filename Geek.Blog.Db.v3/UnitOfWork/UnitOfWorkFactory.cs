using Geek.Blog.Db.UnitOfWork;
using Geek.Blog.Posts.Factories;
using Geek.Blog.Posts.Interfaces;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private UnitOfWorkFactory() { }

        private UnitOfWorkFactory _factory;
        
        private UnitOfWorkFactory factory => _factory ?? (_factory = new UnitOfWorkFactory());


        public IBlogUnitOfWork Readonly()
        {
            return factory.GetUnitOfWork<BlogUnitOfWork, BlogContext>("Readonly");
        }

        public IBlogUnitOfWork ReadWrite()
        {
            return factory.GetUnitOfWork<BlogUnitOfWork, BlogContext>("ReadWrite");
        }

        public void RecreateDb()
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

        public TUnitOfWork GetUnitOfWork<TUnitOfWork, C>(string connectionName) where TUnitOfWork : class, IBlogUnitOfWork where C : BlogContext
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
