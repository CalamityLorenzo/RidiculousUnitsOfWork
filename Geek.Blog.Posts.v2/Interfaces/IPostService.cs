using Geek.Blog.Posts.DomainModel;
using System;

namespace Geek.Blog.Posts.Services
{
    public interface IPostService
    {
        CompletePost GetPost(Guid Id);
        CompletePost GetPost(string Url);
        void UpdatePost(CompletePost updatedPost);
    }
}