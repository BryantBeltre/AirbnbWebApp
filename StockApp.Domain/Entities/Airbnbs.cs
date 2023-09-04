using Airbnb.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Domain.Entities
{
    public class Airbnbs : AuditableBaseEntity
    {
        public string Name { get; set; }

        public string Ubication { get; set; }

        public string Owner { get; set; }

        public string Description { get; set; }

        public string UrlImg { get; set; }

        public double Priece { get; set; }

        //Navigation Property Tipo
        public int TipoId { get; set; }
        
        public Tipo Tipo { get; set; }
         
        // Navigation Property User
        public int UserId { get; set; }

        public User User { get; set; }




    }
}
