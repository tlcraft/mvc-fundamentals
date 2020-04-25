using Shared.Models;
using System.Collections.Generic;

namespace Shared.Services
{
    public interface IUserService
    {
        List<UserModel> GetAllUsers();
        UserModel GetUser(int id);
        int AddUser(UserModel newUser);
        int UpdateUser(UserModel selectedUser);
    }
}
