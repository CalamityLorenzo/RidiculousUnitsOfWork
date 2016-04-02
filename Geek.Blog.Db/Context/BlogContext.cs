using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Geek.Blog.Db.Domain;

namespace Geek.Blog.Db.Context
{
    internal class BlogContext : DbContext
    {
       public BlogContext(DbContextOptions opts) : base(opts)
        {}
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ;
            
            // optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Inital Catalog=pclBlogDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //   base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostHead>().HasKey(o => o.PostId);
            modelBuilder.Entity<PostHead>().ToTable("PostsHeader");
            modelBuilder.Entity<PostHead>().Property(o => o.Title).HasMaxLength(128);
            modelBuilder.Entity<PostHead>().Property(o => o.Url).HasMaxLength(255);
            modelBuilder.Entity<PostHead>().HasIndex(o => o.Url).IsUnique(true);
            modelBuilder.Entity<PostHead>().HasOne(o => o.PostMeta).WithOne(p=>p.PostHeader).HasForeignKey<PostMetaData>(o => o.PostId);

            modelBuilder.Entity<PostMetaData>().HasKey(o => o.MetaDataId);
            modelBuilder.Entity<PostMetaData>().ToTable("PostsMetaData");

            modelBuilder.Entity<PostBody>().HasKey(o => o.PostBodyId);
            modelBuilder.Entity<PostBody>().HasOne(o => o.PostHeader).WithOne().HasForeignKey<PostBody>(o => o.PostId);
            modelBuilder.Entity<PostBody>().ToTable("PostsBodys");
        }

        public DbSet<PostHead> PostsHeader { get; set; }
        public DbSet<PostMetaData> PostsMetaData { get; set; }
        public DbSet<PostBody> PostsBody { get; set; }

    }
}
