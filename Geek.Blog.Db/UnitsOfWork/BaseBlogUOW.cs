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
    public abstract class BaseBlogUOW : IReadWriteUnitOfWork, IDisposable
    {
        readonly DbContext _ctx;
        private bool _completed;

        virtual protected string ConnectionString { get; }

        public BaseBlogUOW()
        {
            DbContextOptionsBuilder opts = new DbContextOptionsBuilder();
            opts.UseSqlServer(this.ConnectionString);
            _ctx = new BlogContext(opts.Options);
            this.PostBody = new PostBodyWrite(_ctx);
            this.PostHeader = new PostHeadersWrite(_ctx);
            this.PostMetaData = new PostMetaWrite(_ctx);
        }

        public IBlogContent PostBody
        {
            get; private set;
        }

        public IBlogHeaders PostHeader
        {
            get; private set;
        }

        public IBlogMeta PostMetaData
        {
            get; private set;
        }

        public void Complete()
        {
            this._completed = true;
            this._ctx.SaveChanges();
        }

        public void Dispose()
        {
            if (_completed)
            {
                if (_ctx != null)
                {
                    this._ctx.SaveChanges();
                }
            }

            if(_ctx != null)
            {
                this._ctx.Dispose();
            }
        }
    }
}
