using Dtos.Concrete.GenderDto;
using FluentValidation;

namespace Business.ValidationRules.Gender
{
    public class GenderUpdateDtoValidator:AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
