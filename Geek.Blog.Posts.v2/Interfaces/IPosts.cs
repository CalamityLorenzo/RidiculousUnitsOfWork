using Geek.Blog.Posts.DomainModel;
using System;

namespace Geek.Blog.Posts.Interfaces
{
    public interface IPosts
    {
        BlogPost GetPost(Guid Id);
        BlogPost GetPost(string Url);
        void UpdatePost(BlogPost post);
        void AddPost(BlogPost newPost);
    }
}