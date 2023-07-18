using Dtos.Abstract;

namespace Dtos.Concrete.AppUserDto
{
    public class AppUserUpdateDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
    }
}
