using Geek.Blog.Db.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Geek.Blog.Posts.Interfaces;
using Geek.Blog.Posts.DomainModel;
using Geek.Blog.Posts.DomainModel.Projections;

namespace Geek.Blog.Db.Repositories
{
    public class SqlTagRepository : BaseRepository<PostTags>, ITags
    {
        public SqlTagRepository(DbContext ctx) : base(ctx)
        {
        }

        public void AddTagToPost(Guid PostId, string Tag)
        {
            this.Entities.Add(new PostTags { PostId = PostId, TagName = Tag });
        }

        public void AddTagToPost(Guid PostId, IEnumerable<string> Tags)
        {
            this.Entities.AddRange(Tags.Select(tgNme => new PostTags { PostId = PostId, TagName = tgNme })); ;
        }

        public IGrouping<string, BlogPostInfo> GetPostsWithTagName(string tagName)
        {
            var PostInfo = Entities.Include(o=>o.PostHeader).Include(o=>o.PostHeader.PostMeta).Where(o=>o.TagName == tagName);
            return new PostInfoByTag(tagName, PostInfo.Select(o => o.PostHeader.PostMeta.MapBlogPostInfo()));
        }

        public BlogPostTag GetTag(Guid PostId, string tag)
        {
            var postTag = this.Entities.FirstOrDefault(o => o.PostId == PostId && o.TagName == tag);
            return postTag?.MapBlogPostTag() ?? BlogPostTag.Empty();
        }

        public IEnumerable<BlogPostTag> GetTags(Guid PostId)
        {
            var tags = this.Entities.Where(o => o.PostId == PostId);
            return tags.Select(o => o.MapBlogPostTag()).ToList();
        }

        public void RemoveTagFromPost(Guid PostId, string Tag)
        {
            var postTag = this.Entities.FirstOrDefault(o => o.PostId == PostId && o.TagName == Tag);
            this.Entities.Remove(postTag);
        }
    }
}
