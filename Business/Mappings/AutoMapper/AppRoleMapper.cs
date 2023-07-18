using AutoMapper;
using Dtos.Concrete.AppRoleDto;
using Entities.Concrete;

namespace Business.Mappings.AutoMapper
{
    public class AppRoleMapper : Profile
    {
        public AppRoleMapper()
        {
            CreateMap<AppRoleCreateDto, AppRole>().ReverseMap();
            CreateMap<AppRoleListDto, AppRole>().ReverseMap();
            CreateMap<AppRoleUpdateDto, AppRole>().ReverseMap();
        }
    }
}
