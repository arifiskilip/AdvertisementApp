using Dtos.Abstract;

namespace Dtos.Concrete.AppUserDto
{
    public class AppUserSignInDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
