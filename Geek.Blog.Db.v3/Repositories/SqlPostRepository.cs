using Geek.Blog.Posts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geek.Blog.Posts.DomainModel;
using Microsoft.Data.Entity;
using Geek.Blog.Db.Domain;
using System.Configuration;
using Microsoft.Data.Entity.Extensions;

namespace Geek.Blog.Db.Repositories
{
    public class SqlPostRepository : BaseRepository<PostBody>, IPosts
    {
        internal SqlPostRepository(DbContext ctx): base(ctx)
        {
        }

        public BlogPost GetPost(string Url)
        {
            var post = this.Entities.Include(o => o.PostHeader).Include(o => o.PostHeader.PostMeta).Where(o => o.PostHeader.Url == Url).FirstOrDefault();
            return post?.MapCompletePost() ?? BlogPost.Empty();
        }

        public  BlogPost GetPost(Guid Id)
        {
            var post = this.Entities.Include(o => o.PostHeader).Include(o => o.PostHeader.PostMeta).FirstOrDefault(o => o.PostId == Id);
            return post?.MapCompletePost() ?? BlogPost.Empty();
        }

        public  void UpdatePost(BlogPost post)
        {
            throw new NotImplementedException();
        }
    }
}
