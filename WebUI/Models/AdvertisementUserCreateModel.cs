using Common.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace WebUI.Models
{
    public class AdvertisementUserCreateModel
    {
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }
        public int AdvertisementAppUserStatusId { get; set; } = (int)AdvertisementUserStatusType.Başvuruldu;
        public int MilitaryStatusId { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public IFormFile CvPath { get; set; }
    }
}
