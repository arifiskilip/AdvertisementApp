using Dtos.Abstract;
using System;

namespace Dtos.Concrete.ProvidedServiceDto
{
    public class ProvidedServiceListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
