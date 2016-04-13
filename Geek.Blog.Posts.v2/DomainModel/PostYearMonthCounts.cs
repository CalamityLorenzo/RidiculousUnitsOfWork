using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.DomainModel
{
    public class PostYearMonthCounts : IGrouping<int, PostMonthCounts>
    {
        readonly List<PostMonthCounts> MonthCount;
        public PostYearMonthCounts(int Year, IEnumerable<PostMonthCounts> MonthAndCount)
        {
            this.MonthCount = new List<PostMonthCounts>(MonthAndCount);
            this.Key = Year;
        }

        public int Key
        {
            get; set;

        }

        public IEnumerator<PostMonthCounts> GetEnumerator()
        {
            return this.MonthCount.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
