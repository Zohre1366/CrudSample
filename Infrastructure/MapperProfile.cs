using Domain.Entities;
using Application.Dtos;
using AutoMapper;
using Domain.Enums;
using Infrastructure.Utilities;

namespace Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.GenderTitle, x => x.MapFrom(src => EnumExtension.GetEnumDescription((GenderEnum)src.Gender)));
            CreateMap<Person, CreatePersonDto>().ReverseMap();
            CreateMap<Person, UpdatePersonDto>().ReverseMap();
        }
    }
}

