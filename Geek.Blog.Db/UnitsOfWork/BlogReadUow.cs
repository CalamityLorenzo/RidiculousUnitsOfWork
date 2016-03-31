using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.UnitsOfWork
{
    public class BlogReadUow : BaseBlogUOW
    {
        protected override string ConnectionString
        {
            get
            {
                return "Data Source =.\\SQLEXPRESS; Initial Catalog = pclBlogDb; Integrated Security = True";
            }
        }
    }
}
