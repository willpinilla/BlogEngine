using BlogEngine.Utilities.Entities;

namespace BlogEngine.Services.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPosts();
        Task<IEnumerable<Post>> GetUserPosts(int userId);
        Task CreatePost(Post post);
        Task AddCommentToPost(Comment comment);
        Task SubmitPost(int postId);
        Task ApprovePost(int userId, int postId);
        Task RejectPost(int userId, int postId, string comment);
    }
}
