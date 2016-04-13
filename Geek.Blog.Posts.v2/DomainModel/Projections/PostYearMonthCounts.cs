using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Geek.Blog.Posts.DomainModel.Projections
{
    internal class PostYearMonthCounts : IGrouping<int, PostMonthCounts>
    {
        private IEnumerable<PostMonthCounts> months;
       
        public PostYearMonthCounts(int year, IEnumerable<PostMonthCounts> months)
        {
            this.Key = year;
            this.months = months;
        }

        public int Key { get; }

        public IEnumerator<PostMonthCounts> GetEnumerator()
        {
            return this.months.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.months.GetEnumerator();
        }
    }
}