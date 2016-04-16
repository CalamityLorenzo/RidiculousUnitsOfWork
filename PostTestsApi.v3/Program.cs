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
using Geek.Blog.Posts.DomainModel;

namespace PostTestsApi.v3
{
    //IPostService ps = new PostService(blg.Posts);
    //var postcPost = ps.GetPost(Guid.Parse("14E504A0-24FF-4C41-46B2-08D35BD7D2F1")); //Guid.Parse("36C92209-B7A7-4B9F-7A38-08D35BB5E001")
    //                                                                                // var postcPost = ps.GetPost("waggon-fuse-tricorn-dimethyltryptamines-immunoelectrophoretically-brucine-paisley-loitering-inherences");
    //Console.WriteLine(postcPost.Title + " " + postcPost.Url);
    //            IPostsInfoService pInfo = new PostsInfoService(blg.PostInfo);
    //var listOfInts = pInfo.GetAvailableYears();

    //            foreach (var item in listOfInts)
    //            {
    //                Console.WriteLine(item);
    //            }

    class Program
    {
        static void Main(string[] args)
        {
            BlogManager.SetConnection = () => UnitOfWorkFactory.Instance.ReadWrite(); 

            BlogPost bp = new BlogPost("My New Post", "Holy-poster-moley", "this is a new text", "total complete bastards eatiing foops", DateTime.Now);
            BlogPost bp2 = new BlogPost("Another Clever post", "Crazy-post-Craze", "SAupposedf ways of creaeting information about your applicvation", "May the lorem ipsum of lipsum lorem be faithful", DateTime.Now, DateTime.Now);
            using (BlogManager Bm = BlogManager.Create())
            {
                Bm.PostService.AddPost(bp);
            }
        
        }
    }
}
