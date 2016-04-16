using Geek.Blog.Posts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.Services
{
    // Handles the connections and stuff
    // instantiate this, you create the entire application
    public class BlogManager : IDisposable
    {
        private bool _disposed = false;
        public IPostService PostService { get; }
        public IPostsInfoService PostInfo { get; }
        public ITagsService PostTags { get; }
        private IBlogUnitOfWork bunitOfWork;

        private BlogManager(IBlogUnitOfWork blogData)
        {
            PostService = new PostService(blogData.Posts);
            PostInfo = new PostsInfoService(blogData.PostInfo);
            PostTags = new TagsService(blogData.Tags);
            this.bunitOfWork = blogData;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BlogManager()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                this.bunitOfWork.Dispose();
            }

            _disposed = true;
        }
        public static Func<IBlogUnitOfWork> SetConnection { get; set; }

        public static BlogManager Create()
        {
            if (SetConnection == null)
            {
                throw new ArgumentNullException("Set Connection must be assigned");
            }
            return new BlogManager(SetConnection());
        }
    }
}
