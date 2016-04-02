using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Interfaces
{
    public interface IReadonlyUnitOfWork : IUnitOfWork
    {
        IBlogContentReader PostBody { get; }
        IBlogHeadersReader PostHeader { get; }
        IBlogMetaReader PostMetaData { get; }
    }
}
