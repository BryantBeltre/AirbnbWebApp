using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Application.ViewModel.Tipos
{
    public class TipoSaveViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Description { get; set; }
    }
}
