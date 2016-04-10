using Geek.Blog.Posts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Geek.Blog.Posts.Services;
using Geek.Blog.Db.Repositories;

namespace PostTestsApi.v3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IPostService ps = new PostService(new SqlPostRepository());

        }
    }
}
