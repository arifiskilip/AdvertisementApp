﻿using System.Collections.Generic;

namespace Entities.Concrete
{
    public class AppRole : BaseEntity
    {
        public string Definition { get; set; }


        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
