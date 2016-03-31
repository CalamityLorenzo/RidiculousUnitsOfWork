using Geek.Blog.Db.Domain;
using Geek.Blog.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Geek.Blog.Db.Repositories
{
    //public class PostHeadersRead : BaseReadRepository<PostHead, Guid>, IBlogHeaders
    //{
    //    internal PostHeadersRead(DbContext ctx) : base(ctx)
    //    {
    //    }
    //}

    public class PostHeadersWrite : BaseReadWriteRepository<PostHead, Guid>, IBlogHeaders
    {
        internal PostHeadersWrite(DbContext ctx) : base(ctx)
        {
        }
    }
}
