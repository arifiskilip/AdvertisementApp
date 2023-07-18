
using FluentValidation;
using System;
using WebUI.Models;

namespace WebUI.Validations
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x=> x.Password).NotEmpty().MinimumLength(3).Equal(x=> x.ConfirmPassword);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3);
            RuleFor(x => new
            {
                x.UserName,
                x.FirstName
            }).Must(x => CanNotFirstname(x.UserName, x.FirstName)).WithMessage("Kullanıcı adı, Adınızı içeremez!").When(x=> x.UserName != null && x.FirstName != null);
            RuleFor(x => x.GenderId).Must(isSelected).WithMessage("Lütfen cinsiyet seçiniz!");
        }

        private bool isSelected(int arg)
        {
            if (arg == 0)
            {
                return false;
            }
            return true;
        }

        private bool CanNotFirstname(string userName, string firstName)
        {
            return !userName.Contains(firstName);
        }
    }
}
