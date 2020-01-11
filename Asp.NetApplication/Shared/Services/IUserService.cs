using Shared.Models;

namespace Shared.Services
{
    public interface IUserService
    {
        UserModel GetUser(int id);
    }
}
