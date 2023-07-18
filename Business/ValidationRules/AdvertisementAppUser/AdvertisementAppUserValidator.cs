using Common.Enums;
using Dtos.Concrete.AdvertisementAppUserDto;
using FluentValidation;

namespace Business.ValidationRules.AdvertisementAppUser
{
    public class AdvertisementAppUserValidator : AbstractValidator<AdvertisementAppUserDto>
    {
        public AdvertisementAppUserValidator()
        {
            RuleFor(x => x.WorkExperience).NotEmpty();
            RuleFor(x => x.CvPath).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId == (int)MilitaryStatusType.Tecilli);
        }
    }
}
