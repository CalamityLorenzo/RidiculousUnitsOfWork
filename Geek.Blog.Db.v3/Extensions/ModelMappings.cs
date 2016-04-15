using Geek.Blog.Db.Domain;
using Geek.Blog.Posts.DomainModel;
using Geek.Blog.Posts.DomainModel.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Geek.Blog.Db.Domain
{
    public static class MapExtensions
    {
        public static BlogPost MapCompletePost(this PostBody @this)
        {
            BlogPost cPost = new BlogPost(@this.PostId, @this.PostHeader.Title, @this.PostHeader.Url,@this.PostHeader.PostMeta.IntroText, @this.PostText, @this.PostHeader.PostMeta.DateCreated, @this.PostHeader.PostMeta.LastModifed);
            return cPost;
        }

        public static BlogPostInfo MapBlogPostInfo(this PostMetaData @this)
        {
            if (@this == null)
            {
                return BlogPostInfo.Empty();
            }
            else
            {
                return new BlogPostInfo(@this.PostHeader.Title, @this.PostHeader.Url, @this.IntroText, @this.DateCreated, @this.LastModifed);
            }
        }
            
        public static BlogPostTag MapBlogPostTag(this PostTags @this)
        {
            return new BlogPostTag(@this.TagName);
        }
    }
}
