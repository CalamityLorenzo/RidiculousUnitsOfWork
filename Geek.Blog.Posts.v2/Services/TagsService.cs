using Geek.Blog.Posts.DomainModel;
using Geek.Blog.Posts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geek.Blog.Posts.Services
{
    public class TagsService : ITagsService
    {
        private readonly ITags Tags;
        public TagsService(ITags tagsRepo)
        {
            Tags = tagsRepo;
        }

        public IEnumerable<string> GetTagsForPost(Guid Id)
        {
            return Tags.GetTags(Id).Select(o=>o.Text);
        }
        public void AddTagToPost(Guid Id, string Tag)
        {
            Tags.AddTagToPost(Id, Tag);
        }
        public void AddTagsToPost(Guid Id, IEnumerable<string> Tags)
        {
            this.Tags.AddTagToPost(Id, Tags);
        }
        public void RemoveTagFromPost(Guid Id, string Tag)
        {
            BlogPostTag tag = this.Tags.GetTag(Id, Tag);
            
            if (tag != BlogPostTag.Empty())
            {
                this.Tags.RemoveTagFromPost(Id, Tag);
            }

        }

    }
}
