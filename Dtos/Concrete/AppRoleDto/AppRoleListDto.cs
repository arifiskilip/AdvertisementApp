using Dtos.Abstract;

namespace Dtos.Concrete.AppRoleDto
{
    public class AppRoleListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }

    }
}
