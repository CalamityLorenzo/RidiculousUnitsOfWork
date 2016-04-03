using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.Models
{
    public class CompletePost
    {

        public CompletePost(string title, string url, string intro, string body)
        {
            this.Intro = intro;
            this.Title = title;
            this.Body = body;
            this.Url = url;
            this.DateCreated = DateTime.Now;
            this.LastModified = DateTime.Now;
        }

        public CompletePost(string title, string url, string intro, string body, DateTime created, DateTime lastModified) : this(title, url, intro, body)
        {
            this.DateCreated = created;
            this.LastModified = lastModified;    
        }

        public CompletePost(string title, string url, string intro, string body, DateTime created)
        {
            this.Intro = intro;
            this.Title = title;
            this.Body = body;
            this.Url = url;
            this.DateCreated = created;
            this.LastModified = DateTime.Now;
        }

        public string Title { get; private set; }
        public string Url { get; private set; }
        public string Intro { get; private set; }
        public string Body { get; private set; }
        public DateTime DateCreated { get; protected set; }
        public DateTime LastModified { get; protected set; }

    }
}
