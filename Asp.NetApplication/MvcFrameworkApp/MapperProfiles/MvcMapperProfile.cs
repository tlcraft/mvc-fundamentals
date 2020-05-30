using AutoMapper;
using DAL;
using MvcFrameworkApp.Models;
using Shared.Models;

namespace MvcFrameworkApp.MapperProfiles
{
    public class MvcMapperProfile : Profile
    {
        public MvcMapperProfile()
        {
            CreateMap<GameFormViewModel, GameModel>()
                .ForMember(dest => dest.GenreType, opt => opt.MapFrom(src => new GenreType { Id = src.GenreTypeId } ));

            CreateMap<CustomerFormViewModel, UserModel>()
                .ForMember(dest => dest.MembershipType, opt => opt.MapFrom(src => new MembershipType { Id = src.MembershipTypeId }));
        }
    }
}