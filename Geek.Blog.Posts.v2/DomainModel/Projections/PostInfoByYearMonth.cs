using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.DomainModel.Projections
{
    public class PostInfoByYearMonth : IGrouping<int, IGrouping<string, IEnumerable<BlogPostInfo>>>
    {
        IEnumerable<IGrouping<string, IEnumerable<BlogPostInfo>>> _postsByMonth;

        public PostInfoByYearMonth(int Year, IEnumerable<IGrouping<string, IEnumerable<BlogPostInfo>>> PostMonthInfo)
        {
            this.Key = Year;

            this._postsByMonth = new List<IGrouping<string, IEnumerable<BlogPostInfo>>>(PostMonthInfo);
        }

        public int Key { get; set; }


        public IEnumerator<IGrouping<string, IEnumerable<BlogPostInfo>>> GetEnumerator()
        {
            return this._postsByMonth.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}
