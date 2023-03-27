using BlogEngine.Utilities.Entities;
using BlogEngine.Utilities.PayLoad;

namespace BlogEngine.Services.Contracts
{
    public interface IUserService
    {
        Task<UserDTO> ValidateUser(UserPayLoad userPayLoad);
        Task<bool> ValidateUserProfile(User user);
    }
}
