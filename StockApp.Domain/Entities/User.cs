﻿using Airbnb.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public ICollection<Airbnbs> Airbnbs { get; set; }            

    }
}
