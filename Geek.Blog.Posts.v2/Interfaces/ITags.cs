using System;
using System.Collections.Generic;
using System.Linq;
using Geek.Blog.Posts.DomainModel;

namespace Geek.Blog.Posts.Interfaces
{
    public interface ITags
    {
        IEnumerable<BlogPostTag> GetTags(Guid id);
        IGrouping<string, BlogPostInfo> GetPostsWithTagName(string tagName);
        void AddTagToPost(Guid PostId, IEnumerable<string> Tags);
        void AddTagToPost(Guid PostId, string Tag);
        void RemoveTagFromPost(Guid PostId, string Tag);
        BlogPostTag GetTag(Guid id, string tag);
    }
}
