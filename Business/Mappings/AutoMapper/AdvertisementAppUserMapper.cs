using AutoMapper;
using Dtos.Concrete.AdvertisementAppUserDto;
using Entities.Concrete;

namespace Business.Mappings.AutoMapper
{
    public class AdvertisementAppUserMapper : Profile
    {
        public AdvertisementAppUserMapper()
        {
            CreateMap<AdvertisementAppUserDto, AdvertisementAppUser>().ReverseMap();
        }
    }
}
