using Dtos.Abstract;

namespace Dtos.Concrete.GenderDto
{
    public class GenderListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
