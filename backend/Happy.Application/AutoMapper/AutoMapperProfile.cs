using AutoMapper;
using Happy.Application.Models.Orphanage;
using Happy.Domain.Entities;

namespace Happy.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrphanageRequestModel, Orphanage>();
            CreateMap<Orphanage, OrphanageResponseModel>();
        }
    }
}
