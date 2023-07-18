using Dtos.Concrete.AdvertisementDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.Advertisement
{
    public class AdvertisementCreateDtoValidator : AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(x => x.CreatedDate).NotEmpty();
        }
    }
}
