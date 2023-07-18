using Dtos.Concrete.GenderDto;
using FluentValidation;

namespace Business.ValidationRules.Gender
{
    public class GenderCreateDtoValidator:AbstractValidator<GenderCreateDto>
    {
        public GenderCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
