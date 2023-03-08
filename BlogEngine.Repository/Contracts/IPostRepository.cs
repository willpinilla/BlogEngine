using BlogEngine.Utilities.Entities;

namespace BlogEngine.Repository.Contracts
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts();
        Task<IEnumerable<Post>> GetUserPosts(int userId);
        Task<IEnumerable<Post>> GetPendingPosts();
        Task CreatePost(Post post);
        Task AddCommentToPost(Comment comment);
        Post GetPost(int postId);
        Task UpdatePostStatus(int postId, string status);
        Task ApprovePost(int userId, int postId);
        Task RejectPost(int userId, int postId, string comment);
    }
}
