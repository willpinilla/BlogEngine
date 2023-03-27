using BlogEngine.Services.Contracts;
using BlogEngine.Utilities.Entities;
using BlogEngine.Utilities.PayLoad;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("ValidateUser")]
        public async Task<UserDTO> ValidateUser([FromBody] UserPayLoad userPayLoad)
        {
            return await _userService.ValidateUser(userPayLoad);
        }
    }
}
