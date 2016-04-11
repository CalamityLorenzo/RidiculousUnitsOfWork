﻿using Geek.Blog.Posts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geek.Blog.Posts.DomainModel;
using Microsoft.Data.Entity;
using Geek.Blog.Db.Domain;
using System.Configuration;

namespace Geek.Blog.Db.Repositories
{
    public class SqlPostRepository : IPosts
    {
        DbContext _ctx { get;}

        //internal SqlPostRepository(DbContext ctx)
        //{
        //    _ctx = ctx;
        //}

        public SqlPostRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ReadWrite"].ConnectionString;
            DbContextOptionsBuilder opts = new DbContextOptionsBuilder();
            opts.UseSqlServer(connectionString);
            _ctx = new BlogContext(opts.Options);
        }

        public CompletePost GetPost(string Url)
        {
            var post = _ctx.Set<PostBody>().Include(o => o.PostHeader).Where(o => o.PostHeader.Url == Url).FirstOrDefault();
            return (post == null) ? post.MapCompletePost() : CompletePost.Empty();
        }

        public  CompletePost GetPost(Guid Id)
        {
            var post = _ctx.Set<PostBody>().Include(o => o.PostHeader).Where(o => o.PostHeader.PostId == Id).FirstOrDefault();
            return (post == null) ? CompletePost.Empty() : CompletePost.Empty();
        }

        public  void UpdatePost(CompletePost post)
        {
            throw new NotImplementedException();
        }
    }
}
