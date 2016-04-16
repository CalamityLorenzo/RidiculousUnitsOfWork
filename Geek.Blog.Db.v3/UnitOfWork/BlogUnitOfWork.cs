using Geek.Blog.Db.Repositories;
using Geek.Blog.Posts.Interfaces;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Extensions;
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
        private bool hasSaved = false;
        private DbContext _ctx { get; }
        internal BlogUnitOfWork(DbContext Context):this()
        {
            _ctx = Context;

        }

        public BlogUnitOfWork()
        {
            if (_ctx == null)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["ReadWrite"].ConnectionString;
                DbContextOptionsBuilder opts = new DbContextOptionsBuilder();
                opts.UseSqlServer(connectionString);
                _ctx = new BlogContext(opts.Options);
           //     _ctx.LogToConsole();
            }

            this.Posts = new SqlPostRepository(_ctx);
            this.PostInfo = new SqlPostInfoRepository(_ctx);
            this.Tags = new SqlTagRepository(_ctx);
        }

        public IPostsInfo PostInfo { get; }

        public IPosts Posts { get; }
        public ITags Tags { get; }

        public void Complete()
        {
            _ctx.SaveChanges();
            hasSaved = true;

        }

        public void Dispose()
        {
            if (_ctx != null)
            {
                if (hasSaved != true)
                {
                    _ctx.SaveChanges();
                }
                _ctx.Dispose();
            }
        }
    }
}
