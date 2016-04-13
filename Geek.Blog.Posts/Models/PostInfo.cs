using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.Models
{
    //bunch of projections

    public class PostInfo
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string InfoText { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModifed { get; set; }
        public override string ToString()
        {
            var infoData = InfoText.Length;
            return $"{Title} {InfoText.Substring(0,infoData>50?50:infoData)} {Created.ToShortDateString()}";
        }
    }

    public class PostMonthCounts
    {
        public PostMonthCounts(string Month, int Count)
        {
            this.Month = Month;
            this.Count = Count;
        }
        public string Month { get;  }
        public int Count { get; }

        public override string ToString()
        {
            return $"{Month} ({Count})";
        }
    }

    public class PostInfoByMonth : IGrouping<string, PostInfo>
    {
        IEnumerable<PostInfo> _postInfo;

        public PostInfoByMonth(string Month, IEnumerable<PostInfo> PostInfo)
        {
            this.Key = Month;
            this._postInfo = new List<PostInfo>(PostInfo);
        }

        public string Key
        {
            get; private set;
        }

        public IEnumerator<PostInfo> GetEnumerator()
        {
            return this._postInfo.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class PostInfoByYearMonth : IGrouping<int, IGrouping<string, IEnumerable<PostInfo>>>
    {
        IEnumerable<IGrouping<string, IEnumerable<PostInfo>>> _postsByMonth;

        public PostInfoByYearMonth(int Year, IEnumerable<IGrouping<string, IEnumerable<PostInfo>>> PostMonthInfo)
        {
            this.Key = Year;

            this._postsByMonth = new List<IGrouping<string, IEnumerable<PostInfo>>>(PostMonthInfo);
        }

        public int Key { get; set; }
        

        public IEnumerator<IGrouping<string, IEnumerable<PostInfo>>> GetEnumerator()
        {
            return this._postsByMonth.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

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
