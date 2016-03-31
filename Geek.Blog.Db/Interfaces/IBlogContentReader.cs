using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Interfaces
{
    interface IBlogContentReader : IReadonlyRepository<string, int>
    {
    }
}
