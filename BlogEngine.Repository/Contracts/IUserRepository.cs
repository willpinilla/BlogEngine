using BlogEngine.Utilities.Entities;
using BlogEngine.Utilities.PayLoad;

namespace BlogEngine.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User> ValidateUser(UserPayLoad userPayLoad);
        Task<bool> ValidateUserProfile(User user);
        User GetUser(int userId);
    }
}
