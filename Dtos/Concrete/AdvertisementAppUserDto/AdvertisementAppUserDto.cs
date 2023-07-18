using Common.Enums;
using Dtos.Abstract;
using System;

namespace Dtos.Concrete.AdvertisementAppUserDto
{
    public class AdvertisementAppUserDto : IDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }
        public int AdvertisementAppUserStatusId { get; set; } = (int)AdvertisementUserStatusType.Başvuruldu;
        public int MilitaryStatusId { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }
    }
}
