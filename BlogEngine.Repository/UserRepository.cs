using BlogEngine.Repository.Contracts;
using BlogEngine.Utilities.Entities;
using BlogEngine.Utilities.PayLoad;

namespace BlogEngine.Repository
{
    public class UserRepository: IUserRepository
    {
        private BlogEngineContext _context;

        public UserRepository(BlogEngineContext context)
        {
            _context = context;
        }

        public async Task<User> ValidateUser(UserPayLoad userPayLoad)
        {
            var user = _context.Users.Where(x => x.UserName == userPayLoad.UserName && x.UserPassword == userPayLoad.UserPassword).First();
            if (user == null) { return null; }
            return user;
        }

        public async Task<bool> ValidateUserProfile(User user)
        {
            var userDB = _context.Users.Single(x => x.Id == user.Id && x.ProfileId == user.ProfileId);
            if (userDB == null) 
            { 
                return false; 
            }
            return true;
        }

        public User GetUser(int userId)
        {
            var result = _context.Users.Find(userId);
            return result;
        }
    }
}
