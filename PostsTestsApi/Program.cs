﻿using Geek.Blog.Posts;
using Geek.Blog.Posts.Models;
using PostsTestsApi.DbCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PostsTestsApi
{
    class Program
    {

        static RET GenericUsing<iDispable, RET>(Func<iDispable> statement, Func<iDispable, RET> BooomUse) where iDispable : IDisposable
        {
            using (var x = statement())
            {
                return BooomUse(x);
            }
        }

        static void Main(string[] args)
        {

            //bool rec = true;
            //Recreate(rec, 750);

            //BlogPostInformation bpi = new BlogPostInformation();
            //var years = bpi.GetAllAvailableYears();
            //foreach (var year in years)
            //{
            //    Console.WriteLine(year);
            //}
            //BlogPosts bPosts = new BlogPosts();
            //var items = bpi.GetPostInfoForMonth(2016, 4);


            var timeDoc = GenericUsing(
                ()=>new WebClient(),
                (client) => XDocument.Parse(client.DownloadString("http://time.gov/actualtime.cgi"))).Root.Attribute("time").Value;

            Console.WriteLine(timeDoc);

            //foreach (var item in items)
            //{
            //    Console.WriteLine(item.Url);
            //}


            //var newItem = bpi.GetPostInfoForUrl("disbowelling-crepuscles-distraite-departee");
            //var existingItem = bPosts.GetPost(newItem.Url);
            //Console.WriteLine(existingItem.Title);

            //var moreITems = bpi.GetPostInfoForMonth(items.Key, 4);

            //foreach (var item in moreITems)
            //{
            //    Console.WriteLine(item);
            //}


            //            var newPost = new NewBlogPost("Wiggle", "hitler-hifive-string", "The rag of winds, plauged his heart. under.", @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ullamcorper hendrerit condimentum. Nulla sapien neque, ullamcorper ac lorem id, egestas congue ligula. Donec nisl felis, interdum sit amet arcu et, sollicitudin consequat purus. Mauris posuere, tortor quis gravida hendrerit, elit lacus tempus quam, pellentesque hendrerit dolor lectus feugiat odio. Proin eget laoreet diam. Phasellus eget metus rutrum, pellentesque odio ut, molestie est. Praesent in interdum urna, nec aliquam erat. Cras at enim fermentum, varius orci ut, placerat nisi. Donec scelerisque lacus at congue accumsan.
 
            //Praesent rhoncus libero a tincidunt laoreet. Nulla vitae sapien commodo, consequat ipsum eget, ultrices lorem.Mauris varius sed massa vel malesuada. Ut a nisl eu enim dapibus fermentum.Sed id aliquam sapien. Aenean consectetur est nulla, sed aliquet tortor ornare ac. Proin tellus tellus, scelerisque id aliquam vitae, vulputate a dolor. Duis at metus nec orci porttitor ornare.In in orci vel nisi auctor feugiat vel et nunc. Mauris vitae consequat dolor. Pellentesque quis velit nisl.

            //Aliquam vel volutpat velit, ornare fringilla metus. Sed ipsum tellus, iaculis et leo sed, placerat porttitor sapien. Donec egestas ipsum quam, a dictum purus vestibulum finibus. Quisque pharetra ornare tellus a ultricies. Vivamus sit amet tincidunt orci, in convallis nisi. Aenean feugiat magna nunc, sit amet feugiat risus feugiat at.Cras vel ante eu arcu fermentum varius vitae non risus. Mauris vel laoreet nibh. Praesent in viverra justo. Vestibulum vitae sapien id neque interdum pretium suscipit dapibus mi.");

            //            var posts = new BlogPosts();
            //            posts.CreateNewPost(newPost);


        }


        static void Recreate(bool rec, int numRecs)
        {
            if (rec)
            {
                Console.WriteLine("Rebuilding Db");
                Console.WriteLine("Press any key");

                ConsoleKeyInfo kPress = Console.ReadKey(true);
                if (kPress.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Skipping...");
                    return;
                }
                else
                {
                    Console.WriteLine("Here we go ${numRecs} being created");
                    DataGenerator Dg = new DataGenerator();
                    Dg.RecreateDb(numRecs);
                }

            }

        }
    }
}
