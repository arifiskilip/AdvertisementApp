using AutoMapper;
using Dtos.Concrete.AdvertisementAppUserDto;
using Dtos.Concrete.AppUserDto;
using WebUI.Models;

namespace WebUI.Mapping
{
    public class UserCreateModelMapper : Profile
    {
        public UserCreateModelMapper()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>().ReverseMap();
        }
    }

    public class AdvertisementAppUserModelMapper : Profile
    {
        public AdvertisementAppUserModelMapper()
        {
            CreateMap<AdvertisementUserCreateModel, AdvertisementAppUserDto>().ReverseMap();
        }
    }
}
