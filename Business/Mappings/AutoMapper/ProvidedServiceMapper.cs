using AutoMapper;
using Dtos.Concrete.ProvidedServiceDto;
using Entities.Concrete;

namespace Business.Mappings.AutoMapper
{
    public class ProvidedServiceMapper : Profile
    {
        public ProvidedServiceMapper()
        {
            CreateMap<ProvidedServiceCreateDto,ProvidedService>().ReverseMap();
            CreateMap<ProvidedServiceUpdateDto,ProvidedService>().ReverseMap();
            CreateMap<ProvidedServiceListDto,ProvidedService>().ReverseMap();
        }
    }
}
