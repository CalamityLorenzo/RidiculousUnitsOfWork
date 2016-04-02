using Geek.Blog.Db.Interfaces;
using Geek.Blog.Db.Repositories;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.UnitOfWork
{
    public class BlogUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _ctx;
        private bool _complete = false;
        internal BlogUnitOfWork(DbContext ctx)
        {
            this._ctx = ctx;
            this.PostBody = new PostBodyRepository(_ctx);
            this.PostHeader = new PostHeadRepository(_ctx);
            this.PostMetaData = new PostMetadataRepository(_ctx);
        }

        public IBlogContent PostBody { get; private set; }

        public IBlogHeaders PostHeader { get; private set; }

        public IBlogMeta PostMetaData { get; private set; }

        public void Complete()
        {
            if (!_complete)
            {
                this._ctx.SaveChanges();
            }
        }

        public void Dispose()
        {
            if (this._ctx != null)
            {
                this._ctx.Dispose();
            }
        }
    }
}
