using AutoMapper;
using Core.Persistence.Paging;
using RentACar.Application.Features.Models.Dtos;
using RentACar.Application.Features.Models.Models;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, ModelListDto>()
                .ForMember(dto => dto.BrandName, opt => opt.MapFrom(model => model.Brand.Name))
                .ReverseMap();
            CreateMap<IPaginate<Model>, ModelListViewModel>().ReverseMap();
        }
    }
}