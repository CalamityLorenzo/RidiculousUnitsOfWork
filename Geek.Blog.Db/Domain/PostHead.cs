using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Domain
{
    public class PostHead
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        
        public string Url { get; set; }
        public PostMetaData PostMeta {get;set;}
     
        public override string ToString()
        {
            return $"{Title} {Url}";
        }
    }

    public class PostMetaData
    {
        public PostMetaData()
        {
            var dt = DateTime.Now;
            DateCreated = dt;
            LastModifed = dt;
        }

        public int MetaDataId { get; set; }
        public string IntroText { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModifed { get; set; }

        public Guid PostId { get; set; }
        public PostHead PostHeader { get; set; }
    }

    public class PostBody
    {
        public int PostBodyId { get; set; }
        public string PostText { get; set; }

        public Guid PostId { get; set; }
        public PostHead PostHeader { get; set; }

        public override string ToString()
        {
            return $"{PostBodyId} {PostText.Substring(0, (PostText.Length>150)? 150:PostText.Length)}";
        }
    }

}
