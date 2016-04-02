﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Db.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IBlogContent PostBody { get; }
        IBlogHeaders PostHeader { get; }
        IBlogMeta PostMetaData { get; }
        void Complete();
    }
}