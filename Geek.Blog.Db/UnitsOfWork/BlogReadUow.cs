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
    public class BlogReadUow : IReadonlyUnitOfWork, IDisposable
    {
        protected readonly DbContext _ctx;
       
        public BlogReadUow(DbContext ctx)
        {
            this._ctx = ctx;
            PostBody = new PostBodyRead(_ctx);
            PostHeader = new PostHeadersRead(_ctx);
            PostMetaData = new PostMetaRead(_ctx); 
        }

        public IBlogContentReader PostBody { get; protected set; }

        public IBlogHeadersReader PostHeader { get; protected set; }

        public IBlogMetaReader PostMetaData { get; protected set; }

        public void Complete()
        {
            throw new NotImplementedException("Hans, boob-e. Read only");
        }

        public void Dispose()
        {
            if (_ctx != null)
            {
                _ctx.Dispose();
            }
        }
    }
}
