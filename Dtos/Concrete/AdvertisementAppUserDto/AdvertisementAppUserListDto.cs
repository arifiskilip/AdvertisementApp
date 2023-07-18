using Common.Enums;
using Dtos.Abstract;
using System;

namespace Dtos.Concrete.AdvertisementAppUserDto
{
    public class AdvertisementAppUserListDto : IDto
    {
        public int Id { get; set; }
        public string AdvertisementName { get; set; }
        public string AppUserName { get; set; }
        public string GenderName { get; set; }
        public string AdvertisementAppUserStatusName { get; set; }
        public string MilitaryStatusName { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }
    }
}
