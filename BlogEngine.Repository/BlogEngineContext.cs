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
            modelBuilder.Entity<Profile>().HasData(new Profile 
                                                   { 
                                                       Id = 1, 
                                                       Name = "Public" 
                                                   },
                                                   new Profile 
                                                   { 
                                                       Id = 2, 
                                                       Name = "Writer" 
                                                   },
                                                   new Profile 
                                                   { 
                                                       Id = 3, 
                                                       Name = "Editor" 
                                                   });

            modelBuilder.Entity<User>().HasData(new User
                                                {
                                                    Id = 1,
                                                    Name = "public",
                                                    ProfileId = 1,
                                                    Email = "public@blogengine.com",
                                                    UserName = "public",
                                                    UserPassword = "public"
                                                },
                                                new User 
                                                { 
                                                    Id = 2, 
                                                    Name = "writer", 
                                                    ProfileId = 2, 
                                                    Email = "writer@blogengine.com", 
                                                    UserName = "writer", 
                                                    UserPassword = "writer" 
                                                },
                                                new User
                                                {
                                                    Id = 3,
                                                    Name = "editor",
                                                    ProfileId = 3,
                                                    Email = "editor@blogengine.com",
                                                    UserName = "editor",
                                                    UserPassword = "editor"
                                                });

            modelBuilder.Entity<Post>().HasData(new Post
                                                { 
                                                    Id = 1,
                                                    Title = "First Post",
                                                    Description = "This is the first post",
                                                    WriterId = 2,
                                                    CreationDate = DateTime.Now,
                                                    Status = "PENDING APPROVAL"
                                                },
                                                new Post
                                                {
                                                   Id = 2,
                                                   Title = "Post Completed",
                                                   Description = "This is a published post",
                                                   WriterId = 2,
                                                   CreationDate = DateTime.Now,
                                                   EditorId = 3,
                                                   EditorComments = "Good job",
                                                   RevisionDate = DateTime.Now,
                                                   Status = "APPROVED"
                                                });

            modelBuilder.Entity<Comment>().HasData(new Comment
                                                   { 
                                                       Id = 1,
                                                       Description = "Nice blog!",
                                                       CreationDate= DateTime.Now,
                                                       PostId = 2
                                                   });
        }
    }
}
