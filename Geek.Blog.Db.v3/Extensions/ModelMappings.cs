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
        public static CompletePost MapCompletePost(this PostBody @this)
        {
            CompletePost cPost = new CompletePost(@this.PostHeader.Title, @this.PostHeader.Url, "", @this.PostText);
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
    }
}
