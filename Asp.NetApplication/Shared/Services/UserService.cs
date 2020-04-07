using AutoMapper;
using DAL;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Services
{
    public class UserService : IUserService
    {
        private EfContext efContext;
        private IMapper mapper;

        public UserService(EfContext efContext, IMapper mapper)
        {
            this.efContext = efContext;
            this.mapper = mapper;
        }

        public UserModel GetUser(int id)
        {
            var user = this.efContext.Users.Find(id);
            var userModel = this.mapper.Map<User, UserModel>(user);
            return userModel;
        }

        public List<UserModel> GetAllUsers()
        {
            var users = this.efContext.Users.ToList();
            var userModels = this.mapper.Map<List<User>, List<UserModel>>(users);
            return userModels;
        }
    }
}
