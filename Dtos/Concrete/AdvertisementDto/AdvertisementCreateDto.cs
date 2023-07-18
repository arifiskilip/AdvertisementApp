using Dtos.Abstract;
using System;

namespace Dtos.Concrete.AdvertisementDto
{
    public class AdvertisementCreateDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
