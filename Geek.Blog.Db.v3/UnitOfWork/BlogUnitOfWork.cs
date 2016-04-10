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
    public class BlogUnitOfWork : IBlogUnitOfWork
    {
        private DbContext _ctx { get; }
        internal BlogUnitOfWork(DbContext Context)
        {
            _ctx = Context;
        }

        public BlogUnitOfWork()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ReadWrite"].ConnectionString;
            DbContextOptionsBuilder opts = new DbContextOptionsBuilder();
            opts.UseSqlServer(connectionString);
            _ctx = new BlogContext(opts.Options);
        }

        public IPostInfo PostInfo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IPosts Posts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ITags Tags
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
