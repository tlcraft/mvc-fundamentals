﻿using AutoMapper;
using DAL;
using Shared.Models;

namespace Shared.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserModel>()
                .ReverseMap()
                .ForMember(dest => dest.MembershipType, opt => opt.Ignore());

            CreateMap<Game, GameModel>()
                .ReverseMap()
                .ForMember(dest => dest.GenreType, opt => opt.Ignore());

            CreateMap<Rental, RentalModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.User))
                .ReverseMap()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Customer.Id))
                    .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.Game.Id))
                    .ForMember(dest => dest.User, opt => opt.Ignore())
                    .ForMember(dest => dest.Game, opt => opt.Ignore());
        }
    }
}
