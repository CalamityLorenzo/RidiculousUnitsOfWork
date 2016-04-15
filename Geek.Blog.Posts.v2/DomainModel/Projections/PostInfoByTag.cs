using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.DomainModel.Projections
{
   public class PostInfoByTag : IGrouping<string, BlogPostInfo>
    {
        IEnumerable<BlogPostInfo> posts;

        public PostInfoByTag(string TagName, IEnumerable<BlogPostInfo> postInfo)
        {
            this.Key = TagName;
            this.posts = new List<BlogPostInfo>(postInfo);
        }

        public string Key { get; }

        public IEnumerator<BlogPostInfo> GetEnumerator()
        {
            return posts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.posts.GetEnumerator();
        }
    }
}
