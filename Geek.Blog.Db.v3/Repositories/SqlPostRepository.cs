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

namespace Geek.Blog.Db.Repositories
{
    public class SqlPostRepository : IPosts
    {
        private DbContext _ctx1;

        DbContext _ctx { get;}

        internal SqlPostRepository(DbContext ctx)
        {
            _ctx = ctx;
        }

        public SqlPostRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ReadWrite"].ConnectionString;
            DbContextOptionsBuilder opts = new DbContextOptionsBuilder();
            opts.UseSqlServer(connectionString);
            _ctx = new BlogContext(opts.Options);
        }

        public SqlPostRepository(DbContext context)
        {
            this._ctx = context;
        }

        public CompletePost GetPost(string Url)
        {
            var post = _ctx.Set<PostBody>().Include(o => o.PostHeader).Include(o => o.PostHeader.PostMeta).Where(o => o.PostHeader.Url == Url).FirstOrDefault();
            return (post == null) ? CompletePost.Empty() : post.MapCompletePost();
        }

        public  CompletePost GetPost(Guid Id)
        {
            var count = _ctx.Set<PostBody>().Count();
            var post = _ctx.Set<PostBody>().Include(o => o.PostHeader).Include(o=>o.PostHeader.PostMeta).Where(o => o.PostId== Id).FirstOrDefault();
            return (post == null) ? CompletePost.Empty() : post.MapCompletePost();
        }

        public  void UpdatePost(CompletePost post)
        {
            throw new NotImplementedException();
        }
    }
}
