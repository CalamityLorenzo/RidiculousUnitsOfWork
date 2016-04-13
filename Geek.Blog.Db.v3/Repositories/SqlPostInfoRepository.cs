using Geek.Blog.Posts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geek.Blog.Posts.DomainModel;
using Microsoft.Data.Entity;
using Geek.Blog.Db.Domain;

namespace Geek.Blog.Db.Repositories
{
    class SqlPostInfoRepository : IPostsInfo
    {
        private readonly DbContext _ctx;
        private readonly DbSet<PostMetaData> Entities;
        public SqlPostInfoRepository(DbContext _ctx)
        {
            this._ctx = _ctx;
            this.Entities = _ctx.Set<PostMetaData>();
        }

        public IEnumerable<string> AllMonthNamesforYear(int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogPostInfo> AllPostInfoForMonth(int year, int month)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetAllYears()
        {
            throw new NotImplementedException();
        }

        public BlogPostInfo GetInfo(Guid id)
        {
            throw new NotImplementedException();
        }

        public BlogPostInfo GetInfo(string url)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogPostInfo> GetPostsForMonth(int year, int month)
        {
            throw new NotImplementedException();
        }
    }
}
