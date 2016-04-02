using Geek.Blog.Db.Interfaces;
using Geek.Blog.Db.Repositories;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.UnitsOfWork
{
    public class BlogReadWriteUow : IReadWriteUnitOfWork, IDisposable
    {
        private readonly DbContext _ctx;
        private bool _complete = false; 
        public BlogReadWriteUow(DbContext ctx)
        {
            this._ctx = ctx;
            this.PostBody = new PostBodyReadWrite(_ctx);
            this.PostHeader = new PostHeadersReadWrite(_ctx);
            this.PostMetaData = new PostMetaReadWrite(_ctx);
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
