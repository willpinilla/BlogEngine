using BlogEngine.Repository.Contracts;
using BlogEngine.Services.Contracts;
using BlogEngine.Utilities.Entities;

namespace BlogEngine.Services
{
    public class PostService: IPostService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public PostService(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;   
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
        }

        public async Task <IEnumerable<Post>> GetUserPosts(int userId)
        {
            var user = _userRepository.GetUser(userId);
            if (user.Profile.Name == "Writer")
            {   
                // Get all the writer posts no matter the status
                return await _postRepository.GetUserPosts(user.Id);
            }
            else if (user.Profile.Name == "Editor")
            {
                // Get only pending post from any writer
                return await _postRepository.GetPendingPosts();
            }
            //Public
            return await _postRepository.GetAllPosts();
        }

        public async Task CreatePost(Post post)
        {
            await _postRepository.CreatePost(post);
        }

        public async Task AddCommentToPost(Comment comment)
        {
            var post = _postRepository.GetPost(comment.PostId);
            if (post.Status == "APPROVED")
            {
                await _postRepository.AddCommentToPost(comment);
            }
        }

        public async Task SubmitPost(int postId)
        {
            var post = _postRepository.GetPost(postId);

            if (post.Status == "IN PROGRESS" || post.Status == "REJECTED")
            {
                await _postRepository.UpdatePostStatus(postId, "PENDING APPROVAL");
            }
        }

        public async Task ApprovePost(int userId, int postId)
        {
            var user = _userRepository.GetUser(userId);
            var userProfile = user.Profile.Name;

            var post = _postRepository.GetPost(postId);

            if (userProfile == "Editor" && post.Status == "PENDING APPROVAL")
            {
                await _postRepository.ApprovePost(userId, postId);
            }
        }

        public async Task RejectPost(int userId, int postId, string comment)
        {
            var user = _userRepository.GetUser(userId);
            var userProfile = user.Profile.Name;

            var post = _postRepository.GetPost(postId);

            if (userProfile == "Editor" && post.Status == "PENDING APPROVAL")
            {
                await _postRepository.RejectPost(userId, postId, comment);
            }
        }
    }
}
