using Business.GenericServiceBase;
using Common.Responses;
using Dtos.Concrete.AdvertisementDto;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdvertisementService : IGenericService<AdvertisementCreateDto,AdvertisementUpdateDto,AdvertisementListDto,Advertisement>
    {
        Task<Response<List<AdvertisementListDto>>> GetAdvertisementListAsync();
    }
}
