using Geek.Blog.Db.UnitsOfWork;
using Geek.Blog.Posts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.Management
{
    public static class BlogDbManagement
    {
        public static void RecreateDb(IEnumerable<NewBlogPost> Posts)
        {
            UnitOfWorkFactory.RecreateDb();

            BlogPosts bp = new BlogPosts();
            bp.CreateNewPosts(Posts);
        }
    }
}
