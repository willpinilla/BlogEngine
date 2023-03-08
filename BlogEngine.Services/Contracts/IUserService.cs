using BlogEngine.Utilities.Entities;
using BlogEngine.Utilities.PayLoad;

namespace BlogEngine.Services.Contracts
{
    public interface IUserService
    {
        Task<User> ValidateUser(UserPayLoad userPayLoad);
        Task<bool> ValidateUserProfile(User user);
    }
}
