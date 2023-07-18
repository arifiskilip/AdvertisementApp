using Dtos.Concrete.ProvidedServiceDto;
using FluentValidation;

namespace Business.ValidationRules.ProvidedService
{
    public class ProvidedServiceListDtoValidator : AbstractValidator<ProvidedServiceListDto>
    {
        public ProvidedServiceListDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
        }
    }
}
