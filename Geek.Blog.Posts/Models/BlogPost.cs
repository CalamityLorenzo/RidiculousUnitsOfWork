using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.Models
{
    public class NewPost
    {
        public NewPost()
        {
            this.DateCreated = DateTime.Now;
        }
        public NewPost(string title, string url, string intro, string body) :this()
        {
            this.Intro = intro;
            this.Title = title;
            this.Body = body;
            this.Url = url;
            this.DateCreated = DateTime.Now;
        }

        public string Title { get; private set; }
        public string Url { get; private set; }
        public string Intro { get; private set; }
        public string Body { get; private set; }
        public DateTime DateCreated { get; protected set; }
    }

    public class Post : NewPost
    {
        public Post(string title, string url, string intro, string body, DateTime lastModified, DateTime created) : base(title, url, intro, body)
        {
            this.DateCreated = created;
            this.LastModified = lastModified;    
        }
        DateTime LastModified { get; set; }
        

    }
}
