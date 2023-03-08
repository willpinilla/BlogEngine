using AutoMapper;
using BlogEngine.Services.Contracts;
using BlogEngine.Utilities.Entities;
using BlogEngine.Utilities.PayLoad;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public PostsController(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;
            _postService = postService;
        }

        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            var result = await _postService.GetAllPosts();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUserPosts")]
        public async Task<IActionResult> GetUserPosts(int userId)
        {
            var result = await _postService.GetUserPosts(userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task CreatePost([FromBody] PostPayLoad post)
        {
            var result = _mapper.Map<Post>(post);
            await _postService.CreatePost(result);
        }

        [HttpPost]
        [Route("AddCommentToPost")]
        public async Task AddCommentToPost([FromBody] CommentPayLoad comment)
        {
            var result = _mapper.Map<Comment>(comment);
            await _postService.AddCommentToPost(result);
        }

        [HttpPost]
        [Route("SubmitPost")]
        public async Task SubmitPost(int postId)
        {
            await _postService.SubmitPost(postId);
        }

        [HttpPost]
        [Route("ApprovePost")]
        public async Task ApprovePost(int userId, int postId)
        {
            await _postService.ApprovePost(userId, postId);
        }

        [HttpPost]
        [Route("RejectPost")]
        public async Task RejectPost(int userId, int postId, string comment)
        {
            await _postService.RejectPost(userId, postId, comment);
        }
    }
}
