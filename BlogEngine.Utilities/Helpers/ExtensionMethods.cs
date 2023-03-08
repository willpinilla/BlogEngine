using BlogEngine.Utilities.Entities;

namespace BlogEngine.Utilities.Helpers
{
    public static class ExtensionMethods
    {
        public static User WithoutPassword(this User user)
        {
            user.UserPassword = null;
            return user;
        }
    }
}
