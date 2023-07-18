using Dtos.Concrete.AppUserDto;
using FluentValidation;

namespace Business.ValidationRules.AppUser
{
    public class AppUserSignInDtoValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInDtoValidator()
        {
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x=> x.UserName).NotEmpty();
        }
    }
}
