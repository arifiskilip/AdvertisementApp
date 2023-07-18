using AutoMapper;
using Business.Mappings.AutoMapper;
using System.Collections.Generic;

namespace Business.Extensions
{
    public static class AutoMapperMapProfileExtension
    {
        private static List<Profile> profiles = new List<Profile>();
        public static List<Profile> GetProfiles(this IMapperConfigurationExpression options)
        {
            profiles.Add(new ProvidedServiceMapper());
            profiles.Add(new AdvertisementMapper());
            profiles.Add(new GenderMapper());
            profiles.Add(new AppUserMapper());

            return profiles;
           
        }
    }
}
