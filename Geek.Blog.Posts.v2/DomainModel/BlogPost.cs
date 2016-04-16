using Geek.Blog.Posts.Interfaces;
using Geek.Blog.Posts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.DomainModel
{
    public class BlogPost
    {
        internal BlogPost() { }

        public BlogPost(string title, string url, string intro, string body)
        {
            this.Intro = intro;
            this.Title = title;
            this.Body = body;
            this.Url = url;
            this.DateCreated = DateTime.Now;
            this.LastModified = DateTime.Now;
        }

        public BlogPost(string title, string url, string intro, string body, DateTime created, DateTime lastModified) : this(title, url, intro, body)
        {
            this.DateCreated = created;
            this.LastModified = lastModified;
        }

        public BlogPost(Guid Id, string title, string url, string intro, string body, IEnumerable<string> Tags, DateTime created, DateTime lastModified) : this(title, url, intro, body, created, lastModified)
        {
            this.Id = Id;
            this.Tags = new List<string>(Tags);

        }

        public BlogPost(string title, string url, string intro, string body, DateTime created) : this(title, url, intro, body)
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
        
        public IEnumerable<string> Tags { get; }

        public static BlogPost Empty()
        {
            return new BlogPost();
        }
    }
}
