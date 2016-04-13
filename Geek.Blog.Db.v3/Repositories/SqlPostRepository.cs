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

        public CompletePost GetPost(string Url)
        {
            var post = this.Entities.Include(o => o.PostHeader).Include(o => o.PostHeader.PostMeta).Where(o => o.PostHeader.Url == Url).FirstOrDefault();
            return (post == null) ? CompletePost.Empty() : post.MapCompletePost();
        }

        public  CompletePost GetPost(Guid Id)
        {
            var post = this.Entities.Include(o => o.PostHeader).Include(o => o.PostHeader.PostMeta).FirstOrDefault(o => o.PostId == Id);
            return (post == null) ? CompletePost.Empty() : post.MapCompletePost();
        }

        public  void UpdatePost(CompletePost post)
        {
            throw new NotImplementedException();
        }
    }
}
