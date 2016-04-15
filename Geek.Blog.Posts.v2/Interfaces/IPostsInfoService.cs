using System;
using System.Collections.Generic;
using System.Linq;
using Geek.Blog.Posts.DomainModel;
using Geek.Blog.Posts.DomainModel.Projections;

namespace Geek.Blog.Posts.Services
{
    public interface IPostsInfoService
    {
        IEnumerable<int> GetAvailableYears();
        IGrouping<int, PostMonthCounts> GetAvailablePostCountByYear(int year);
        BlogPostInfo GetPostInfo(string url);
        BlogPostInfo GetPostInfo(Guid id);
        IEnumerable<BlogPostInfo> GetPostInfoForMonth(int year, int month);
    }
}