using Geek.Blog.Posts.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace Geek.Blog.Posts.Interfaces
{
    public interface IPostInfo
    {
        IEnumerable<BlogPostInfo> AllPostInfoForMonth(int year, int month);
        IGrouping<int, PostMonthCounts> GetAvailablePostsCountByYear(int year);
        BlogPostInfo GetPostInfoForUrl(string postUrl);
    }
}