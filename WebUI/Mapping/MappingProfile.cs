using AutoMapper;
using Model.Entities;
using WebUI.Dtos;

namespace WebUI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PayDto, Order>()
                .ReverseMap();


        }
    }
}
