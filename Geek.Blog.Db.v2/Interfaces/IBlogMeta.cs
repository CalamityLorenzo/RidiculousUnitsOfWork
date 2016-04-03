using Geek.Blog.Db.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Interfaces
{
    public interface IBlogMeta : IRepository<PostMetaData, int>
    {
        IEnumerable<PostMetaData> AllBlogsInfoForMonth(int year, int month);
        IEnumerable<string> AllMonthNamesForYear(int year);
        PostMetaData PostInfoForUrl(string postUrl);
    }
}
