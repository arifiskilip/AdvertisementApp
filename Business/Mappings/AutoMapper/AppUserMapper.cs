using AutoMapper;
using Dtos.Concrete.AppUserDto;
using Entities.Concrete;

namespace Business.Mappings.AutoMapper
{
    public class AppUserMapper : Profile
    {
        public AppUserMapper()
        {
            CreateMap<AppUserCreateDto, AppUser>().ReverseMap();
            CreateMap<AppUserUpdateDto, AppUser>().ReverseMap();
            CreateMap<AppUserListDto, AppUser>().ReverseMap();
            CreateMap<AppUserSignInDto, AppUser>().ReverseMap();    
            CreateMap<AppUserSignInDto, AppUserListDto>().ReverseMap();    
        }
    }
}
