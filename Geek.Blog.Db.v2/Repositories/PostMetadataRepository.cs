using Geek.Blog.Db.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Geek.Blog.Db.Interfaces;
using System.Linq.Expressions;
using System.Globalization;

namespace Geek.Blog.Db.Repositories
{
    class PostMetadataRepository : BaseRepository<PostMetaData, int>, IBlogMeta
    {
        public PostMetadataRepository(DbContext ctx) : base(ctx)
        {
        }

        public IEnumerable<PostMetaData> AllBlogsInfoForMonth(int year, int month)
        {
            return Find(o => o.DateCreated.Year == year && o.DateCreated.Month == month).ToList();
        }

        public IEnumerable<string> AllMonthNamesForYear(int year)
        {
           return Find(o => o.DateCreated.Year == year).
                                Select(o => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(o.DateCreated.Month));
        }

        public override IEnumerable<PostMetaData> Find(Expression<Func<PostMetaData, bool>> predicate)
        {
            return this.Entities.Include(o => o.PostHeader).Where(predicate);
        }

        public PostMetaData PostInfoForUrl(string postUrl)
        {
            return this.Find(o => o.PostHeader.Url == postUrl).FirstOrDefault();
        }
    }
}
