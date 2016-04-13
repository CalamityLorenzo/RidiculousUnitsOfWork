using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.DomainModel
{
    public class CompletePost
    {
        internal CompletePost() { }

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

        public CompletePost(Guid Id, string title, string url, string intro, string body, DateTime created, DateTime lastModified) : this(title, url, intro, body, created, lastModified)
        {
            this.Id = Id;
        }

        public CompletePost(string title, string url, string intro, string body, DateTime created) : this(title, url, intro, body)
        {
            this.LastModified = DateTime.Now;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Url { get; }
        public string Intro { get; }
        public string Body { get; }
        public DateTime DateCreated { get; protected set; }
        public DateTime LastModified { get; protected set; }

        public static CompletePost Empty()
        {
            return new CompletePost();
        }
    }
}
