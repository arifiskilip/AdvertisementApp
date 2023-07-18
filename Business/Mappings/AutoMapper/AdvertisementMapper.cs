using AutoMapper;
using Dtos.Concrete.AdvertisementDto;
using Entities.Concrete;

namespace Business.Mappings.AutoMapper
{
    public class AdvertisementMapper : Profile
    {
        public AdvertisementMapper()
        {
            CreateMap<AdvertisementCreateDto, Advertisement>().ReverseMap();
            CreateMap<AdvertisementUpdateDto, Advertisement>().ReverseMap();
            CreateMap<AdvertisementListDto, Advertisement>().ReverseMap();
        }
    }
}
