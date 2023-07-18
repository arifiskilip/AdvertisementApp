using Dtos.Concrete.AdvertisementDto;
using FluentValidation;

namespace Business.ValidationRules.Advertisement
{
    public class AdvertisementUpdateDtoValidator : AbstractValidator<AdvertisementUpdateDto>
    {
        public AdvertisementUpdateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(x => x.CreatedDate).NotEmpty();
        }
    }
}
