using AutoMapper;
using Business.Abstract;
using Business.GenericServiceBase;
using DataAccess.UnitOfWork;
using Dtos.Concrete.ProvidedServiceDto;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class ProvidedServiceManager : GenericManager<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>, IProvidedServiceService
    {
        public ProvidedServiceManager(IUoW uoW, IMapper mapper, IValidator<ProvidedServiceCreateDto> creatValidator, IValidator<ProvidedServiceUpdateDto> updateValidator) : base(uoW, mapper, creatValidator, updateValidator)
        {
        }
    }
}
