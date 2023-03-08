using BlogEngine.Repository.Contracts;
using BlogEngine.Utilities.Entities;

namespace BlogEngine.Repository
{
    public class PostRepository: IPostRepository
    {
        private BlogEngineContext _context;

        public PostRepository(BlogEngineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            var posts = _context.Posts.Where(x => x.Status == "APPROVED");
            return posts;
        }

        public async Task<IEnumerable<Post>> GetUserPosts(int userId)
        {
            var posts = _context.Posts.Where(x => x.WriterId == userId);
            return posts;
        }

        public async Task<IEnumerable<Post>> GetPendingPosts()
        {
            var posts = _context.Posts.Where(x => x.Status == "PENDING APPROVAL" || x.Status == "REJECTED");
            return posts;
        }

        public async Task CreatePost(Post post) 
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public async Task AddCommentToPost(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public Post GetPost(int postId)
        {
            var post = _context.Posts.Find(postId);
            return post;
        }

        public async Task UpdatePostStatus(int postId, string status)
        {
            var post = _context.Posts.Find(postId);
            post.Status = status;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public async Task ApprovePost(int userId, int postId)
        {
            var post = _context.Posts.Find(postId);
            post.EditorId = userId;
            post.RevisionDate = DateTime.Now;
            post.Status = "APPROVED";
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public async Task RejectPost(int userId, int postId, string comment)
        {
            var post = _context.Posts.Find(postId);
            post.EditorId = userId;
            post.EditorComments = comment;
            post.RevisionDate = DateTime.Now;
            post.Status = "REJECTED";
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}