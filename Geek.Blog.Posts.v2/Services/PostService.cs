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

        public CompletePost GetPost(Guid Id)
        {
            return this.Posts.GetPost(Id);
        }

        public CompletePost GetPost(string Url)
        {
            return this.Posts.GetPost(Url);
        }

        public void UpdatePost(CompletePost updatedPost)
        {
            throw new NotImplementedException();
        }
    }
}
