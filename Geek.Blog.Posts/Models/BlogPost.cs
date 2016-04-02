using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.Models
{
    public class NewBlogPost
    {
        public NewBlogPost()
        {
            this.DateCreated = DateTime.Now;
        }
        public NewBlogPost(string title, string url, string intro, string body) :this()
        {
            this.Intro = intro;
            this.Title = title;
            this.Body = body;
            this.Url = url;
        }

        public string Title { get; private set; }
        public string Url { get; private set; }
        public string Intro { get; private set; }
        public string Body { get; private set; }
        public DateTime DateCreated { get; private set; }
    }
}
