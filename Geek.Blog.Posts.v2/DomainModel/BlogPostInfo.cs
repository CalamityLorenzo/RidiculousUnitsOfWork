using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.DomainModel
{
    public class BlogPostInfo
    {
        internal BlogPostInfo() { }

        public BlogPostInfo(string Title, string Url, string InfoText, DateTime Created, DateTime LastModified)
        {
            this.Title = Title;
            this.Url = Url;
            this.InfoText = InfoText;
            this.Created = Created;
            this.LastModifed = LastModifed;
        }
        public string Title {get;}
        public string Url {get;}
        public string InfoText {get;}
        public DateTime Created {get;}
        public DateTime LastModifed {get;}
        public override string ToString()
        {
            var infoData = InfoText.Length;
            return $"{Title} {InfoText.Substring(0, infoData > 50 ? 50 : infoData)} {Created.ToShortDateString()}";
        }

        public static BlogPostInfo Empty()
        {
            return new BlogPostInfo();
        }
    }
}
