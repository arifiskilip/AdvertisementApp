using AutoMapper;
using Business.Mappings.AutoMapper;
using System.Collections.Generic;

namespace Business.Helpers
{
    namespace Udemy.AdvertisementApp.Business.Helpers
    {
        public static class ProfileHelper
        {
            public static List<Profile> GetProfiles()
            {

                return new List<Profile>
            {
               new ProvidedServiceMapper(),
               new AdvertisementMapper(),
               new GenderMapper(),
               new AppUserMapper(),
               new AppRoleMapper(),
               new AdvertisementAppUserMapper()
            };
            }
        }
    }
}
