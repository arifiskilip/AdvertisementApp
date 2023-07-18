using Dtos.Abstract;

namespace Dtos.Concrete.ProvidedServiceDto
{
    public class ProvidedServiceCreateDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}
