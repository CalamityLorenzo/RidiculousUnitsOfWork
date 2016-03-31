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
    //public class PostBodyRead : BaseReadRepository<PostBody, int>, IBlogContent
    //{
    //    internal PostBodyRead(DbContext ctx) : base(ctx)
    //    {
    //    }
    //}

    public class PostBodyWrite : BaseReadWriteRepository<PostBody, int>, IBlogContent
    {
        internal PostBodyWrite(DbContext ctx) : base(ctx)
        { }
    }
}
