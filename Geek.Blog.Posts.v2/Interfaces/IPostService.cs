using Geek.Blog.Posts.DomainModel;
using System;

namespace Geek.Blog.Posts.Services
{
    public interface IPostService
    {
        BlogPost GetPost(Guid Id);
        BlogPost GetPost(string Url);
        void UpdatePost(BlogPost updatedPost);
    }
}