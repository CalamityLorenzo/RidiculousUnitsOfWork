using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Interfaces
{
   public interface IReadWriteUnitOfWork
    {
        IBlogContent PostBody { get; }
        IBlogHeaders PostHeader { get; }
        IBlogMeta PostMetaData { get; }
    }
}
