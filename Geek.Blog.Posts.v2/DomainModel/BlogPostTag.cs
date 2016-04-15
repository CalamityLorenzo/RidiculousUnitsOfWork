using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.DomainModel
{
    public class BlogPostTag
    {
        public BlogPostTag(string Text)
        {
            //this.Id = Id;
            this.Text = Text;

        }
        internal BlogPostTag() { }
        //public Guid Id { get; }
        public string Text { get;   }

        public static BlogPostTag Empty()
        {
            return new BlogPostTag();
        }
    }
}
