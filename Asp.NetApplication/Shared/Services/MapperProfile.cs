using AutoMapper;
using DAL;
using Shared.Models;

namespace Shared.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<Game, GameModel>()
                .ReverseMap()
                .ForPath(s => s.GenreType, opt => opt.Ignore());
        }
    }
}
