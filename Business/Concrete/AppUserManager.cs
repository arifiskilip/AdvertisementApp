using AutoMapper;
using Business.Abstract;
using Business.Extensions;
using Business.GenericServiceBase;
using Common.Responses;
using DataAccess.UnitOfWork;
using Dtos.Concrete.AppRoleDto;
using Dtos.Concrete.AppUserDto;
using Entities.Concrete;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AppUserManager : GenericManager<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IValidator<AppUserCreateDto> _appUserCreateDtovalidator;
        private readonly IUoW _uoW;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserSignInDto> _appUserSignInDtoValidator;
        public AppUserManager(IUoW uoW, IMapper mapper, IValidator<AppUserCreateDto> creatValidator, IValidator<AppUserUpdateDto> updateValidator, IValidator<AppUserSignInDto> appUserSignInDtoValidator) : base(uoW, mapper, creatValidator, updateValidator)
        {
            _appUserCreateDtovalidator = creatValidator;
            _uoW = uoW;
            _mapper = mapper;
            _appUserSignInDtoValidator = appUserSignInDtoValidator;
        }

        async Task<IResponse<AppUserCreateDto>> IAppUserService.CreateWithRoleAsync(AppUserCreateDto userCreateDto, int roleId)
        {
            var validator = _appUserCreateDtovalidator.Validate(userCreateDto);
            if (validator.IsValid)
            {
                var user = _mapper.Map<AppUser>(userCreateDto);
                await _uoW.GetRepository<AppUser>().AddAsync(user);
                AppUserRole appUserRole = new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId,
                };
                await _uoW.GetRepository<AppUserRole>().AddAsync(appUserRole);
                await _uoW.CommitAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success, userCreateDto);
            }
            return new Response<AppUserCreateDto>(userCreateDto, validator.ConvertToCustomeValidationError());
        }

        async Task<IResponse<AppUserListDto>> IAppUserService.SignInAsync(AppUserSignInDto userSignInDto)
        {
            var validator = _appUserSignInDtoValidator.Validate(userSignInDto);
            if (validator.IsValid)
            {
                var userControl = await _uoW.GetRepository<AppUser>().GetAllAsync(null,true);
            
                if (userControl.Any(x => x.UserName == userSignInDto.UserName && x.Password == userSignInDto.Password))
                {
                    var dto = _mapper.Map<AppUserListDto>(userControl.FirstOrDefault(x => x.UserName == userSignInDto.UserName && x.Password == userSignInDto.Password));
                    return new Response<AppUserListDto>(ResponseType.Success, dto);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Kullanıcı adı veya şifre hatası.");
            }
            return new Response<AppUserListDto>(ResponseType.NotFound,"Kullanıcı adı veya şifre boş olamaz.");
        }

        async Task<IResponse<List<AppRoleListDto>>> IAppUserService.GetUserRolesAsync(int userId)
        {
            var roles =await _uoW.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId), true);
            if (roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "Mevcut Rol Yok");
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);
            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);
            
        }
    }
}
