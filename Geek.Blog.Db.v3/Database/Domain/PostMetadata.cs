using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Domain
{
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
}
