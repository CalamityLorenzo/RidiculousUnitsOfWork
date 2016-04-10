using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Domain
{
   public class PostTags
    {
        public Guid PostId { get; set; }
        public string TagName { get; set; }
        public PostHead PostHeader { get; set; }
    }
}
