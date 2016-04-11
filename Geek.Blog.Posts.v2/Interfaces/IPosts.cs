using Geek.Blog.Posts.DomainModel;
using System;

namespace Geek.Blog.Posts.Interfaces
{
    public interface IPosts
    {
        CompletePost GetPost(Guid Id);
        CompletePost GetPost(string Url);
        void UpdatePost(CompletePost post);
    }
}