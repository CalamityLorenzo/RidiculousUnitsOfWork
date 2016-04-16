using Geek.Blog.Posts.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geek.Blog.Posts.Interfaces;

namespace Geek.Blog.Posts.Services
{
    // Handles getting a full post
   public class PostService : IPostService
    {
        //private IBlogUnitOfWork blogData;
        IPosts Posts;
        public PostService(IPosts blogData)
        {
            this.Posts = blogData;
        }

        public BlogPost GetPost(Guid Id)
        {
            return this.Posts.GetPost(Id);
        }

        public BlogPost GetPost(string Url)
        {
            return this.Posts.GetPost(Url);
        }

        public void UpdatePost(BlogPost updatedPost)
        {
            throw new NotImplementedException();
        }

        public void AddPost(BlogPost newPost)
        {
            Posts.AddPost(newPost);
        }
    }
}
