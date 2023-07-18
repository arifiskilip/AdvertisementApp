using Common.Responses;
using Dtos.Concrete.AdvertisementAppUserDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponse<AdvertisementAppUserDto>> CreateAsync(AdvertisementAppUserDto dto);
        Task<IResponse<List<AdvertisementAppUserListDto>>> GetAdvertisementAppUserListDtoAsync();
        Task<IResponse<AdvertisementAppUserDto>> PositiveApplicationAsync(int advertisementAppUserId);
        Task<IResponse<AdvertisementAppUserDto>> NegativeApplicationAsync(int advertisementAppUserId);
    }
}
