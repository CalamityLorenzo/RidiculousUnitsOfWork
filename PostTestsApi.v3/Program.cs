using Geek.Blog.Posts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Geek.Blog.Posts.Services;
using Geek.Blog.Db.Repositories;
using Geek.Blog.Db.UnitOfWork;

namespace PostTestsApi.v3
{
    class Program
    {
        static void Main(string[] args)
        {
         
            using(IBlogUnitOfWork blg  = UnitOfWorkFactory.Instance.Readonly())
            {
               
            }
               
            IPostService ps = new PostService(new SqlPostRepository());

        }
    }
}
