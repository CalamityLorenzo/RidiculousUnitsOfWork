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

}
