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
    public class SqlPostRepository :  IPosts
    {
        private DbContext _ctx;

        internal SqlPostRepository(DbContext ctx)
        {
            _ctx = ctx;
        }

        public BlogPost GetPost(string Url)
        {
            var post = _ctx.Set<PostBody>().Include(o => o.PostHeader).Include(o => o.PostHeader.PostMeta).Where(o => o.PostHeader.Url == Url).FirstOrDefault();
            return post?.MapCompletePost() ?? BlogPost.Empty();
        }

        public  BlogPost GetPost(Guid Id)
        {
            var post = _ctx.Set<PostBody>().Include(o => o.PostHeader).Include(o => o.PostHeader.PostMeta).FirstOrDefault(o => o.PostId == Id);
            return post?.MapCompletePost() ?? BlogPost.Empty();
        }

        public  void UpdatePost(BlogPost post)
        {
            throw new NotImplementedException();
        }

        public void AddPost(BlogPost newPost)
        {
            PostHead phead = new PostHead();
            phead.Title = newPost.Title;
            phead.Url = newPost.Url;
            phead.PostMeta = new PostMetaData();
            phead.PostMeta.DateCreated = newPost.DateCreated;
            phead.PostMeta.LastModifed = newPost.LastModified;
            phead.PostMeta.IntroText = newPost.Intro;
           
            this._ctx.Add(phead);
            PostBody pbody = new PostBody();
            pbody.PostId = phead.PostId;
            pbody.PostText = newPost.Body;
            pbody.PostHeader = phead;
            this._ctx.Add(pbody);
            //   this.Entities.Add()
        }
    }
}
