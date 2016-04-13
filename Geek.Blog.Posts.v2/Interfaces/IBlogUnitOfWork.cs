using System;

namespace Geek.Blog.Posts.Interfaces
{
    public interface IBlogUnitOfWork :IDisposable
    {
        IPosts Posts { get; }
        IPostsInfo PostInfo { get; }
        ITags Tags {get;}
        void Complete();
    }
}