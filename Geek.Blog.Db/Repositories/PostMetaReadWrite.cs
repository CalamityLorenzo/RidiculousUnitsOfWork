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
   public class PostMetaReadWrite :BaseReadWriteRepository<PostMetaData, int>,  IBlogMeta
    {
        internal PostMetaReadWrite(DbContext ctx) :base(ctx)
        {

        }
    }
}
