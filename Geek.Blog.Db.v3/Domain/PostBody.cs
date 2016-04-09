using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Domain
{
    public class PostBody
    {
        public int PostBodyId { get; set; }
        public string PostText { get; set; }

        public Guid PostId { get; set; }
        public PostHead PostHeader { get; set; }

        public override string ToString()
        {
            return $"{PostBodyId} {PostText.Substring(0, (PostText.Length > 150) ? 150 : PostText.Length)}";
        }
    }
}
