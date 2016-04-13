using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.DomainModel.Projections
{
    public class PostInfoByMonth : IGrouping<string, BlogPostInfo>
    {
        IEnumerable<BlogPostInfo> _postInfo;

        public PostInfoByMonth(string Month, IEnumerable<BlogPostInfo> PostInfo)
        {
            this.Key = Month;
            this._postInfo = new List<BlogPostInfo>(PostInfo);
        }

        public string Key
        {
            get; private set;
        }

        public IEnumerator<BlogPostInfo> GetEnumerator()
        {
            return this._postInfo.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}
