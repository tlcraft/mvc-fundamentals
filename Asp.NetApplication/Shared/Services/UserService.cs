using AutoMapper;
using DAL;
using Shared.Models;

namespace Shared.Services
{
    public class UserService : IUserService
    {
        private EfContext efContext;
        private IMapper mapper;

        public UserService(EfContext efContext)
        {
            this.efContext = efContext;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            this.mapper = config.CreateMapper();
        }

        public UserModel GetUser(int id)
        {
            var user = this.efContext.Users.Find(id);
            var userModel = mapper.Map<User, UserModel>(user);
            return userModel;
        }
    }
}
