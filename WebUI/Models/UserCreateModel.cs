using Dtos.Concrete.AppUserDto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Models
{
    public class UserCreateModel 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public string ConfirmPassword { get; set; }
        public SelectList Genders { get; set; }
    }
}
