using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.DomainModel
{
    public class BlogPostInfo
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string InfoText { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModifed { get; set; }
        public override string ToString()
        {
            var infoData = InfoText.Length;
            return $"{Title} {InfoText.Substring(0, infoData > 50 ? 50 : infoData)} {Created.ToShortDateString()}";
        }
    }
}
