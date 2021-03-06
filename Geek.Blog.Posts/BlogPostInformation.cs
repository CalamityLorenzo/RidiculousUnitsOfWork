﻿using Geek.Blog.Db.Interfaces;
using Geek.Blog.Db.UnitsOfWork;
using Geek.Blog.Posts.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts
{
    public class BlogPostInformation
    {
        private IUnitOfWork uow;
        private IBlogMeta blogMetaData;

        public BlogPostInformation()
        {
            this.uow = UnitOfWorkFactory.Readonly();
            this.blogMetaData = uow.PostMetaData;
        }

        public IEnumerable<int> GetAllAvailableYears()
        {
            return  this.blogMetaData.AvailableYears().ToList();
        }

        public IGrouping<int, PostMonthCounts> GetAvailablePostsCountByYear(int year)
        {
            var allPostsInYear = this.blogMetaData.AllMonthNamesForYear(year);
            return new PostYearMonthCounts(year, from allPosts in allPostsInYear
                                                 group allPosts by allPosts into grpPosts
                                                 select new PostMonthCounts(grpPosts.Key, grpPosts.Count()));
        }

        public IEnumerable<PostInfo> GetPostInfoForMonth(int year, int month)
        {
            var allPostsInMonth = this.blogMetaData.AllBlogsInfoForMonth(year, month);
            return new List<PostInfo>(from allPosts in allPostsInMonth
                                      select new PostInfo
                                      {
                                          Title = allPosts.PostHeader.Title,
                                          Url = allPosts.PostHeader.Url,
                                          InfoText = allPosts.IntroText,
                                          Created = allPosts.DateCreated,
                                          LastModifed = allPosts.LastModifed
                                      });
        }

        public PostInfo GetPostInfoForUrl(string postUrl)
        {
            var postInfo = this.blogMetaData.PostInfoForUrl(postUrl);
            return new PostInfo
            {
                Created = postInfo.DateCreated,
                InfoText = postInfo.IntroText,
                LastModifed = postInfo.LastModifed,
                Title = postInfo.PostHeader.Title,
                Url = postInfo.PostHeader.Url
            };
        }

    }
}
