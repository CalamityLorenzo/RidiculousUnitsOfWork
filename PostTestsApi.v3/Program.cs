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

            using (IBlogUnitOfWork blg = UnitOfWorkFactory.Instance.Readonly())
            {
                IPostService ps = new PostService(blg.Posts);
                var postcPost = ps.GetPost(Guid.Parse("14E504A0-24FF-4C41-46B2-08D35BD7D2F1")); //Guid.Parse("36C92209-B7A7-4B9F-7A38-08D35BB5E001")
                                                                                                // var postcPost = ps.GetPost("waggon-fuse-tricorn-dimethyltryptamines-immunoelectrophoretically-brucine-paisley-loitering-inherences");
                Console.WriteLine(postcPost.Title + " " + postcPost.Url);
                
            }


        }
    }
}
