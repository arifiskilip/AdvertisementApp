using Dtos.Abstract;

namespace Dtos.Concrete.MilitaryStatusDto
{
    public class MilitaryStatusListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }

    }
}
