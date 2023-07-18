using AutoMapper;
using Business.Abstract;
using Business.GenericServiceBase;
using Common.Responses;
using DataAccess.UnitOfWork;
using Dtos.Concrete.AdvertisementDto;
using Entities.Concrete;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdvertisementManager : GenericManager<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IUoW _uoW;
        private readonly IMapper _mapper;
        public AdvertisementManager(IUoW uoW, IMapper mapper, IValidator<AdvertisementCreateDto> creatValidator, IValidator<AdvertisementUpdateDto> updateValidator) : base(uoW, mapper, creatValidator, updateValidator)
        {
            _uoW = uoW;
            _mapper = mapper;
        }

        public async Task<Response<List<AdvertisementListDto>>> GetAdvertisementListAsync()
        {
            var data = await _uoW.GetRepository<Advertisement>().GetAllAsync(x=> x.Status == true,true);
            var dtos = _mapper.Map<List<AdvertisementListDto>>(data.OrderByDescending(x=> x.CreatedDate));
            return new Response<List<AdvertisementListDto>>(ResponseType.Success, dtos);
        }
    }
}
