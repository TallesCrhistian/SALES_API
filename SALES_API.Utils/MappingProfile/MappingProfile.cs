using AutoMapper;
using SALES_API.Entities;
using SALES_API.Shared.DTOs;
using SALES_API.Shared.ModelViews.Client;

namespace SALES_API.Utils.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ClientCreateViewModel, ClientDTO>();

            CreateMap<ClientDTO, Client>()
                .ReverseMap();

            CreateMap<ClientDTO, ClientViewModel>();

            CreateMap<ClientUpdateViewModel, ClientDTO>();
        }
    }
}
