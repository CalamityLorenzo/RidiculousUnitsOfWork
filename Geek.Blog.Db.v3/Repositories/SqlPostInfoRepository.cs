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
   public class SqlPostInfoRepository : BaseRepository<PostMetaData>, IPostsInfo
    {
        public SqlPostInfoRepository(DbContext _ctx) :  base(_ctx)
        {
        }

        public IEnumerable<string> GetAllMonthNamesforYear(int year)
        {
            return Entities.Where(o => o.DateCreated.Year == year).Select(o => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(o.DateCreated.Month));
        }

        public IEnumerable<BlogPostInfo> GetAllPostsForMonth(int year, int month)
        {
            return Entities.Include(o => o.PostHeader).Where(o => o.DateCreated.Year == year && o.DateCreated.Month == month).Select(o => o.MapBlogPostInfo()).ToList();
        }

        public IEnumerable<int> GetAllYears()
        {
            return Entities.GroupBy(o => o.DateCreated.Year).Select(o => o.Key).ToList();
        }

        public BlogPostInfo GetInfo(Guid id)
        {
            return Entities.Where(o => o.PostId == id).FirstOrDefault().MapBlogPostInfo(); // Select(o => o.MapBlogPostInfo());
        }

        public BlogPostInfo GetInfo(string url)
        {
            return Entities.Include(o=>o.PostHeader).Where(o => o.PostHeader.Url == url).FirstOrDefault().MapBlogPostInfo(); // Select(o => o.MapBlogPostInfo());
            
        }
    }
}
