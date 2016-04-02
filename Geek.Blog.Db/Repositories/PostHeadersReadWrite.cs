using Geek.Blog.Db.Domain;
using Geek.Blog.Db.Interfaces;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Repositories
{
    public class PostHeadersReadWrite : BaseReadWriteRepository<PostHead, Guid>, IBlogHeaders
    {
        internal PostHeadersReadWrite(DbContext ctx) : base(ctx)
        {
        }
    }
}
