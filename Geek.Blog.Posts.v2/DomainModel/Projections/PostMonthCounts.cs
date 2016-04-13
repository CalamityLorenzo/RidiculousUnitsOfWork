namespace Geek.Blog.Posts.DomainModel.Projections
{
    public class PostMonthCounts
    {
        public PostMonthCounts(string Month, int Count)
        {
            this.Month = Month;
            this.Count = Count;
        }
        public string Month { get; private set; }
        public int Count { get; private set; }

        public override string ToString()
        {
            return $"{Month} ({Count})";
        }
    }
}