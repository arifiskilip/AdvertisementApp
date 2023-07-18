using AutoMapper;
using Dtos.Concrete.GenderDto;
using Entities.Concrete;

namespace Business.Mappings.AutoMapper
{
    public class GenderMapper : Profile
    {
        public GenderMapper()
        {
            CreateMap<GenderCreateDto, Gender>().ReverseMap();
            CreateMap<GenderUpdateDto, Gender>().ReverseMap();
            CreateMap<GenderListDto, Gender>().ReverseMap();
        }
    }
}
