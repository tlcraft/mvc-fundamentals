using DAL;

namespace Shared.Services
{
    public class UserService : IUserService
    {
        private EfContext efContext;

        public UserService(EfContext efContext)
        {
            this.efContext = efContext;
        }

        public User GetUser(long id)
        {
            var user = this.efContext.Users.Find(1);
            return user;
        }
    }
}
