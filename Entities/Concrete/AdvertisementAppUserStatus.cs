﻿using System.Collections.Generic;

namespace Entities.Concrete
{
    public class AdvertisementAppUserStatus :BaseEntity
    {
        public string Definition { get; set; }


        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
