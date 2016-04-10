using Geek.Blog.Posts.DomainModel;
using System.Collections.Generic;

namespace Geek.Blog.Posts.Interfaces
{
    public interface IPostInfo
    {
        IEnumerable<BlogPostInfo> AllPostInfoForMonth(int year, int month);
    }
}