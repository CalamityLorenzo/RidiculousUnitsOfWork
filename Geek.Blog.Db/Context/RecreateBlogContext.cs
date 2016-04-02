using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Infrastructure;

namespace Geek.Blog.Db.Context
{
    internal class RecreateBlogContext : BlogContext
    {
        private static bool _created = false;

        public RecreateBlogContext(DbContextOptions opts) : base(opts)
        {
            if (!_created)
            {
              //  Database.EnsureDeleted();
                Database.EnsureCreated();
                _created = true;
            }
        }
    }
}
