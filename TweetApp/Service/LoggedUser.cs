using TweetApp.Repository;

namespace TweetApp.Service
{
    internal class LoggedUser
    {
        private UserRepository repository = new();
        public void Logout(int userId)
        {
            repository.UpdateActiveStatusLoggingOut(userId);
        }
        public void LogIn(int userId)
        {
            repository.UpdateActiveStatusLoggingIn(userId);
        }

    }
}
