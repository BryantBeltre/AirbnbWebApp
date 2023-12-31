﻿using Airbnb.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Domain.Entities
{
    public class Tipo : AuditableBaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Airbnbs> Airbnb { get; set; }
    }
}
