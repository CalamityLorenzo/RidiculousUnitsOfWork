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

    public abstract class PostRepository : IPosts
    {
        public abstract CompletePost GetPost(string Url);

        public abstract CompletePost GetPost(Guid Id);

        public abstract void UpdatePost(CompletePost post);
    }
}