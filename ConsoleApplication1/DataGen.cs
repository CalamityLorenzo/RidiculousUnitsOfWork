using Geek.Blog.Db.Domain;
using Geek.Blog.Db.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class DataGen
    {

        private static string LoremText()
        {
            return @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ullamcorper hendrerit condimentum. Nulla sapien neque, ullamcorper ac lorem id, egestas congue ligula. Donec nisl felis, interdum sit amet arcu et, sollicitudin consequat purus. Mauris posuere, tortor quis gravida hendrerit, elit lacus tempus quam, pellentesque hendrerit dolor lectus feugiat odio. Proin eget laoreet diam. Phasellus eget metus rutrum, pellentesque odio ut, molestie est. Praesent in interdum urna, nec aliquam erat. Cras at enim fermentum, varius orci ut, placerat nisi. Donec scelerisque lacus at congue accumsan.

Praesent rhoncus libero a tincidunt laoreet. Nulla vitae sapien commodo, consequat ipsum eget, ultrices lorem.Mauris varius sed massa vel malesuada. Ut a nisl eu enim dapibus fermentum.Sed id aliquam sapien. Aenean consectetur est nulla, sed aliquet tortor ornare ac. Proin tellus tellus, scelerisque id aliquam vitae, vulputate a dolor. Duis at metus nec orci porttitor ornare.In in orci vel nisi auctor feugiat vel et nunc. Mauris vitae consequat dolor. Pellentesque quis velit nisl.

Aliquam vel volutpat velit, ornare fringilla metus. Sed ipsum tellus, iaculis et leo sed, placerat porttitor sapien. Donec egestas ipsum quam, a dictum purus vestibulum finibus. Quisque pharetra ornare tellus a ultricies. Vivamus sit amet tincidunt orci, in convallis nisi. Aenean feugiat magna nunc, sit amet feugiat risus feugiat at.Cras vel ante eu arcu fermentum varius vitae non risus. Mauris vel laoreet nibh. Praesent in viverra justo. Vestibulum vitae sapien id neque interdum pretium suscipit dapibus mi.";
        }

        public DataGen(int recordCount)
        {
            Random rand = new Random();
            DictionaryReader dr = new DictionaryReader();

            var PostHeaders = new List<PostHead>();

            for (int x = 0; x < recordCount; ++x)
            {
                var wordsPerTitle = rand.Next(4, 12);
                List<string> myTitle = new List<string>();
                for (var y = 0; y < wordsPerTitle; ++y)
                {
                    myTitle.Add(dr[rand.Next(0, (int)dr.lineCount)]);
                }
                var title = String.Join(" ", myTitle.ToArray());
                title = title.Trim().Substring(0, (title.Length > 128) ? 128 : title.Length);
                var urlTotal = String.Join("-", myTitle.ToArray());
                var url = urlTotal.Substring(0, (urlTotal.Length > 255) ? 255 : title.Length);
                PostHeaders.Add(new PostHead { Title = title, Url = url });
            }

            var PostMeta = new List<PostMetaData>();

            using (BlogReadWriteUow uow = new BlogReadWriteUow())
            {
                uow.PostHeader.AddRange(PostHeaders);

                for (var x = 0; x < recordCount; ++x)
                {
                    var dtCreated = new DateTime(rand.Next(2012, 2016), rand.Next(1, 12), rand.Next(1, 28));
                    var dtModifed = dtCreated;

                    var next = rand.Next(1, 10);

                    if (next > 8)
                    {
                        dtModifed = dtCreated.AddDays(rand.Next(1, 80));
                    }


                    var wordsPerTitle = rand.Next(2, 42);
                    List<string> myIntro = new List<string>();
                    for (var y = 0; y < wordsPerTitle; ++y)
                    {
                        myIntro.Add(dr[rand.Next(0, (int)dr.lineCount)]);
                    }

                    PostMeta.Add(new PostMetaData { PostId = PostHeaders[x].PostId, DateCreated = dtCreated, LastModifed = dtModifed, IntroText = String.Join(" ", myIntro) + "." });
                }

                uow.PostMetaData.AddRange(PostMeta);
                List<PostBody> pb = new List<PostBody>();
                for (var x = 0; x < recordCount; ++x)
                {
                    pb.Add(new PostBody { PostId = PostHeaders[x].PostId, PostText = LoremText() });
                }

                uow.PostBody.AddRange(pb);
                uow.Complete();
            }
        }
    }
}
