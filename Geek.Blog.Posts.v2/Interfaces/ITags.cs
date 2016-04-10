using System.Linq;

namespace Geek.Blog.Posts.Interfaces
{
    public interface ITags
    {
        IGrouping<string, string> GetPostsWithTagName(string tagName);
    }
}
