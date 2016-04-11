using Geek.Blog.Posts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geek.Blog.Posts.DomainModel;

namespace Geek.Blog.Db.Repositories
{
    class SqlPostInfoRepository : IPostInfo
    {
        public IEnumerable<BlogPostInfo> AllPostInfoForMonth(int year, int month)
        {
            throw new NotImplementedException();
        }
    }
}
