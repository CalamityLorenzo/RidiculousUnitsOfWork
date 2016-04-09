using Geek.Blog.Posts;
using Geek.Blog.Posts.Management;
using Geek.Blog.Posts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsTestsApi.DbCreation
{
    class DataGenerator
    {
        Random rand = new Random();
        DictionaryReader dr = new DictionaryReader();

        public void RecreateDb(int count)
        {
            List<CompletePost> NewPosts = new List<CompletePost>();

            var newDate = RandomDayFunc();
            for (var x = 0; x < count; ++x)
            {
                var wordsPerTitle = rand.Next(4, 12);
                List<string> myTitle = new List<string>(GetChunkOfWords(rand, wordsPerTitle));

                // random words for a title
                String Title = String.Join(" ", myTitle.ToArray());
                Title = Title.Trim().Substring(0, (Title.Length > 128) ? 128 : Title.Length);
                var urlTotal = String.Join("-", myTitle.ToArray());

                String Url = urlTotal.Substring(0, (urlTotal.Length > 255) ? 255 : Title.Length);
                DateTime dtCreated = newDate();
                DateTime dtModifed = dtCreated;
                var next = rand.Next(1, 10);
                // shouldwe change the modified date?
                if (next > 6)
                {
                    dtModifed = dtCreated.AddDays(rand.Next(1, 80));
                }
                var wordsForIntro = rand.Next(2, 42);
                List<string> myIntro = new List<string>(GetChunkOfWords(rand, wordsForIntro));
                NewPosts.Add(new CompletePost(Title, Url, String.Join(" ", myIntro), LoremText()));
            }

            BlogDbManagement.RecreateDb(NewPosts);

        }

        Func<DateTime> RandomDayFunc()
        {
            DateTime start = new DateTime(2012, 1, 1);
            Random gen = new Random();
            int range = ((TimeSpan)(DateTime.Today - start)).Days;
            return () => start.AddDays(gen.Next(range));
        }

        IEnumerable<string> GetChunkOfWords(Random rand, int numberOfWords)
        {
            DictionaryReader dr = new DictionaryReader();

            List<string> words = new List<string>();
            for(var i=0; i < numberOfWords; ++i)
            {
                words.Add(dr[rand.Next(0, (int)dr.lineCount)]);
            }

            return words;
        }

        private static string LoremText()
        {
            return @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ullamcorper hendrerit condimentum. Nulla sapien neque, ullamcorper ac lorem id, egestas congue ligula. Donec nisl felis, interdum sit amet arcu et, sollicitudin consequat purus. Mauris posuere, tortor quis gravida hendrerit, elit lacus tempus quam, pellentesque hendrerit dolor lectus feugiat odio. Proin eget laoreet diam. Phasellus eget metus rutrum, pellentesque odio ut, molestie est. Praesent in interdum urna, nec aliquam erat. Cras at enim fermentum, varius orci ut, placerat nisi. Donec scelerisque lacus at congue accumsan.

Praesent rhoncus libero a tincidunt laoreet. Nulla vitae sapien commodo, consequat ipsum eget, ultrices lorem.Mauris varius sed massa vel malesuada. Ut a nisl eu enim dapibus fermentum.Sed id aliquam sapien. Aenean consectetur est nulla, sed aliquet tortor ornare ac. Proin tellus tellus, scelerisque id aliquam vitae, vulputate a dolor. Duis at metus nec orci porttitor ornare.In in orci vel nisi auctor feugiat vel et nunc. Mauris vitae consequat dolor. Pellentesque quis velit nisl.

Aliquam vel volutpat velit, ornare fringilla metus. Sed ipsum tellus, iaculis et leo sed, placerat porttitor sapien. Donec egestas ipsum quam, a dictum purus vestibulum finibus. Quisque pharetra ornare tellus a ultricies. Vivamus sit amet tincidunt orci, in convallis nisi. Aenean feugiat magna nunc, sit amet feugiat risus feugiat at.Cras vel ante eu arcu fermentum varius vitae non risus. Mauris vel laoreet nibh. Praesent in viverra justo. Vestibulum vitae sapien id neque interdum pretium suscipit dapibus mi.";
        }
    }
}
