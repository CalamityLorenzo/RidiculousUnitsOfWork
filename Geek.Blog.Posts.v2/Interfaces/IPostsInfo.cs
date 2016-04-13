using Geek.Blog.Posts.DomainModel;
using Geek.Blog.Posts.Services;
using System;
using System.Collections.Generic;

namespace Geek.Blog.Posts.Interfaces
{
    public interface IPostsInfo
    {

        IEnumerable<int> GetAllYears();
        IEnumerable<BlogPostInfo>AllPostInfoForMonth(int year, int month);
        IEnumerable<string> AllMonthNamesforYear(int year);
        IEnumerable<BlogPostInfo> GetPostsForMonth(int year, int month);
        BlogPostInfo GetInfo(string url);
        BlogPostInfo GetInfo(Guid id);
    }
}