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

        private IReadWriteUnitOfWork _dbCtx;

        private IReadWriteUnitOfWork dbCtx
        {
            get
            {
                if (_dbCtx == null)
                {
                    _dbCtx = UnitOfWorkFactory.ReadWrite();
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

        internal BlogPosts(IReadWriteUnitOfWork readWrite)
        {
            dbCtx = readWrite;
        }

        public void CreateNewPosts(IEnumerable<NewBlogPost> posts)
        {
            foreach(var post in posts)
            {
                CreatePost(post);
            }
            dbCtx.Complete();
            dbCtx.Dispose();
            dbCtx = null;
        }

        private void CreatePost(NewBlogPost newPost)
        {
            // create this in stages
            var postHead = new PostHead
            {
                Title = newPost.Title,
                Url = newPost.Url,
                PostMeta = new PostMetaData { IntroText = newPost.Intro }
            };

            dbCtx.PostHeader.Add(postHead);
            var postContent = new PostBody
            {
                PostText = newPost.Body,
                PostId = postHead.PostId
            };
            dbCtx.PostBody.Add(postContent);
        }

        public void CreateNewPost(NewBlogPost newPost)
        {
            try
            {
                CreatePost(newPost);
                dbCtx.Complete();
            }
            finally
            {
                dbCtx.Dispose();
                dbCtx = null;
            }
        }

    }
}
