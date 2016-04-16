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
    public class BlogManager
    {
        public IPostService PostService { get; }
        public IPostsInfoService PostInfo { get; }
        public ITagsService PostTags { get; }
        public BlogManager(IBlogUnitOfWork blogData)
        {
            PostService = new PostService(blogData.Posts);
            PostInfo = new PostsInfoService(blogData.PostInfo);
            PostTags = new TagsService(blogData.Tags);
        }
    }
}
