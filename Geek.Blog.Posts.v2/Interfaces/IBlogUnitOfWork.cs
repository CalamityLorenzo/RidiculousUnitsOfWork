namespace Geek.Blog.Posts.Interfaces
{
    public interface IBlogUnitOfWork
    {
        IPosts Posts { get; }
        IPostInfo PostInfo { get; }
        ITags Tags {get;}
    }
}