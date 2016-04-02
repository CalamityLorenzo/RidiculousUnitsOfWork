using Geek.Blog.Db.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Geek.Blog.Db.Interfaces;

namespace Geek.Blog.Db.Repositories
{
    class PostBodyRepository : BaseRepository<PostBody, int>, IBlogContent
    {
        public PostBodyRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}
