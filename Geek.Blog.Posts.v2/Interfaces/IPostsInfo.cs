using Geek.Blog.Posts.DomainModel;
using Geek.Blog.Posts.Services;
using System;
using System.Collections.Generic;

namespace Geek.Blog.Posts.Interfaces
{
    public interface IPostsInfo
    {
        IEnumerable<int> GetAllYears();
        IEnumerable<BlogPostInfo> GetAllPostsForMonth(int year, int month);
        IEnumerable<string> GetAllMonthNamesforYear(int year);
        BlogPostInfo GetInfo(string url);
        BlogPostInfo GetInfo(Guid id);
    }
}