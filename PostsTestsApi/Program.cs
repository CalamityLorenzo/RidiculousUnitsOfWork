using Geek.Blog.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsTestsApi
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogPostInformation bpi = new BlogPostInformation();
            var items = bpi.GetAvailablePostsCountByYear(2014);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            var moreITems = bpi.GetPostInfoForMonth(items.Key,9);

            foreach(var item in moreITems)
            {
                Console.WriteLine(item);
            }
        }
    }
}
