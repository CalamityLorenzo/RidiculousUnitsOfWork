using Geek.Blog.Posts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geek.Blog.Posts.DomainModel;
using Microsoft.Data.Entity;
using Geek.Blog.Db.Domain;
using System.Globalization;

namespace Geek.Blog.Db.Repositories
{
    class SqlPostInfoRepository : IPostInfo
    {
        private DbContext ctx { get; }
        internal SqlPostInfoRepository(DbContext Context)
        {
            this.ctx = Context;
        }


        public IEnumerable<BlogPostInfo> AllPostInfoForMonth(int year, int month)
        {
            var dta = this.ctx.Set<PostMetaData>().Include(o=>o.PostHeader).Where(o => o.DateCreated.Year == year && o.DateCreated.Month == month).ToList();
            return dta.Select(o => o.MapPostHeader());
        }

        public IGrouping<int, PostMonthCounts> GetAvailablePostsCountByYear(int year)
        {
            var allPosts = ctx.Set<PostMetaData>().Where(o => o.DateCreated.Year == year).Select(o => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(o.DateCreated.Month));
            return new PostYearMonthCounts(year, from allP in allPosts
                                                 group allP by allP into grpPosts
                                                 select new PostMonthCounts(grpPosts.Key, grpPosts.Count()));
        }

        public BlogPostInfo GetPostInfoForUrl(string postUrl)
        {
            throw new NotImplementedException();
        }
    }
}
