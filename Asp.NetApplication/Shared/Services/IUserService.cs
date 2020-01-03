using DAL;
namespace Shared.Services
{
    public interface IUserService
    {
        User GetUser(int id);
    }
}
