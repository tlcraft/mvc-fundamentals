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

        public User GetUser(int id)
        {
            var user = this.efContext.Users.Find(id);
            return user;
        }
    }
}
