using Geek.Blog.Db.Domain;
using Geek.Blog.Db.Interfaces;
using Geek.Blog.Db.UnitsOfWork;
using Geek.Blog.Posts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts
{
    public class BlogPosts
    {
        private bool ManageUowLife = false;

        private IUnitOfWork _dbCtx;
        private IUnitOfWork dbCtx
        {
            get
            {
                if (_dbCtx == null)
                {
                    _dbCtx = UnitOfWorkFactory.ReadWrite();
                    ManageUowLife = true;
                }
                return _dbCtx;
            }
            set
            {
                _dbCtx = value;
            }
        }

        public BlogPosts()
        {

        }

        internal BlogPosts(IUnitOfWork readWrite)
        {
            dbCtx = readWrite;
        }

        public void CreateNewPosts(IEnumerable<CompletePost> posts)
        {
            foreach (var post in posts)
            {
                CreatePost(post);
            }
            dbCtx.Complete();
            dbCtx.Dispose();
            dbCtx = null;
        }

        private void CreatePost(CompletePost post)
        {
            // create this in stages
            var postHead = new PostHead
            {
                Title = post.Title,
                Url = post.Url,
                PostMeta = new PostMetaData { IntroText = post.Intro, DateCreated = post.DateCreated, LastModifed = post.LastModified }
            };

            dbCtx.PostHeader.Add(postHead);
            var postContent = new PostBody
            {
                PostText = post.Body,
                PostId = postHead.PostId
            };
            
        }

      

        public CompletePost GetPost(string url)
        {
            var HeaderAndMeta = dbCtx.PostHeader.FindFirstOrDefault(o => o.Url == url);
            var PostBody = dbCtx.PostBody.FindFirstOrDefault(o => o.PostId == HeaderAndMeta.PostId);

            return new CompletePost(
                title: HeaderAndMeta.Title,
                url: HeaderAndMeta.Url,
                body: PostBody.PostText,
                intro:HeaderAndMeta.PostMeta.IntroText,
                lastModified: HeaderAndMeta.PostMeta.LastModifed,
                created: HeaderAndMeta.PostMeta.LastModifed
                );
        }
    }
}
