using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Application.ViewModel.Airbnb
{
    public class airbnbViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ubication { get; set; }

        public string Owner { get; set; }

        public string Description { get; set; }

        public string UrlImg { get; set; }

        public double Priece { get; set; }

        public int TipoId { get; set; }

        public string TipoName { get; set; }

        public int TipoNameId { get; set; }
    }
}
