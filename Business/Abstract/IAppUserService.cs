using Business.GenericServiceBase;
using Common.Responses;
using Dtos.Concrete.AppRoleDto;
using Dtos.Concrete.AppUserDto;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppUserService : IGenericService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto userCreateDto, int roleId);
        Task<IResponse<AppUserListDto>> SignInAsync(AppUserSignInDto userSignInDto);
        Task<IResponse<List<AppRoleListDto>>> GetUserRolesAsync(int userId);
    }
}
