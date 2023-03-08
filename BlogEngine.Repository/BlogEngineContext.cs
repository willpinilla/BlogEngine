using BlogEngine.Utilities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Repository
{
    public class BlogEngineContext : DbContext
    {
        public BlogEngineContext(DbContextOptions options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
