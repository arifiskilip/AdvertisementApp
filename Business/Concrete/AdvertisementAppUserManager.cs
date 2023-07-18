using AutoMapper;
using Business.Abstract;
using Business.Extensions;
using Common.Enums;
using Common.Responses;
using DataAccess.Contexts;
using DataAccess.UnitOfWork;
using Dtos.Concrete.AdvertisementAppUserDto;
using Dtos.Concrete.AdvertisementDto;
using Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdvertisementAppUserManager : IAdvertisementAppUserService
    {
        private readonly IValidator<AdvertisementAppUserDto> _validator;
        private readonly IUoW _uoW;
        private readonly IMapper _mapper;
        private readonly AdvertisementContext _context;

        public AdvertisementAppUserManager(IValidator<AdvertisementAppUserDto> validator, IUoW uoW, IMapper mapper, AdvertisementContext context)
        {
            _validator = validator;
            _uoW = uoW;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IResponse<AdvertisementAppUserDto>> CreateAsync(AdvertisementAppUserDto dto)
        {
            var dtoValidator = _validator.Validate(dto);
            if (dtoValidator.IsValid)
            {
                var entity = _mapper.Map<AdvertisementAppUser>(dto);
                var entityIsAny = await _uoW.GetRepository<AdvertisementAppUser>().GetAllAsync(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId, true);
                if (entityIsAny.Count > 0)
                {
                    return new Response<AdvertisementAppUserDto>(ResponseType.NotFound, "İlgili ilanda başvurunuz zaten bulunmaktadır.");
                }
                await _uoW.GetRepository<AdvertisementAppUser>().AddAsync(entity);
                await _uoW.CommitAsync();
                return new Response<AdvertisementAppUserDto>(ResponseType.Success, "Başvuru başarılı.");
            }
            return new Response<AdvertisementAppUserDto>(dto, dtoValidator.ConvertToCustomeValidationError());
        }

        public async Task<IResponse<List<AdvertisementAppUserListDto>>> GetAdvertisementAppUserListDtoAsync()
        {

            var data = await _context.AdvertisementAppUsers.Include(x => x.Advertisement).Include(x => x.AppUser).Include(x => x.AppUser.Gender).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus).ToListAsync();
            var result = new List<AdvertisementAppUserListDto>();
            foreach (var item in data)
            {
                result.Add(new()
                {
                    Id = item.Id,
                    AdvertisementAppUserStatusName = item.AdvertisementAppUserStatus.Definition,
                    AdvertisementName = item.Advertisement.Title,
                    AppUserName = item.AppUser.FirstName + " " + item.AppUser.Surname,
                    EndDate = item.EndDate,
                    CvPath = item.CvPath,
                    MilitaryStatusName = item.MilitaryStatus.Definition,
                    WorkExperience = item.WorkExperience,
                    GenderName = item.AppUser.Gender.Definition
                });

            }
            return new Response<List<AdvertisementAppUserListDto>>(ResponseType.Success, result);
        }

        public async Task<IResponse<AdvertisementAppUserDto>> PositiveApplicationAsync(int advertisementAppUserId)
        {
            var repo = _uoW.GetRepository<AdvertisementAppUser>();
            var dto = await repo.GetByIdAsync(advertisementAppUserId);
            var data = _mapper.Map<AdvertisementAppUser>(dto);
            data.AdvertisementAppUserStatusId = (int)AdvertisementUserStatusType.Olumlu;
            repo.Update(data);
            _uoW.Commit();
            return new Response<AdvertisementAppUserDto>(ResponseType.Success,"İşlem Başarılı");
        }
        public async Task<IResponse<AdvertisementAppUserDto>> NegativeApplicationAsync(int advertisementAppUserId)
        {
            var repo = _uoW.GetRepository<AdvertisementAppUser>();
            var dto = await repo.GetByIdAsync(advertisementAppUserId);
            var data = _mapper.Map<AdvertisementAppUser>(dto);
            data.AdvertisementAppUserStatusId = (int)AdvertisementUserStatusType.Olumsuz;
            repo.Update(data);
            _uoW.Commit();
            return new Response<AdvertisementAppUserDto>(ResponseType.Success, "İşlem Başarılı");
        }

    }
}
