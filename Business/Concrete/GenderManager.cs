using AutoMapper;
using Business.Abstract;
using Business.GenericServiceBase;
using DataAccess.UnitOfWork;
using Dtos.Concrete.GenderDto;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class GenderManager : GenericManager<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {
        public GenderManager(IUoW uoW, IMapper mapper, IValidator<GenderCreateDto> creatValidator, IValidator<GenderUpdateDto> updateValidator) : base(uoW, mapper, creatValidator, updateValidator)
        {
        }
    }
}
