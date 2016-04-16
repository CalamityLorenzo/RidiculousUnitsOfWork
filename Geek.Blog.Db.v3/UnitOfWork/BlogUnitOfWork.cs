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
    public class SqlBlogUnitOfWork : IBlogUnitOfWork
    {
        private bool _disposed = false;

        private bool hasSaved = false;
        private DbContext _ctx { get; }
        internal SqlBlogUnitOfWork(DbContext Context)
        {
            _ctx = Context;
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

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                if (_ctx != null)
                {
                    _ctx.Dispose();
                }
            }
            _disposed = true;


        }

        public void Dispose()
        {
            if (hasSaved != true)
            {
                _ctx.SaveChanges();
            }

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SqlBlogUnitOfWork()
        {
            Dispose(false);
        }
    }
}
