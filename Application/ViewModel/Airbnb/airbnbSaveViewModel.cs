using Airbnb.Core.Application.ViewModel.Tipos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Application.ViewModel.Airbnb
{
    public class airbnbSaveViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Ubication { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]

        public string Owner { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string UrlImg { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [DataType(DataType.Currency)]
        public double Priece { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar el tipo de airbnb")]
        public int TipoId { get; set; }

        public List<TipoViewModel> Tipos { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
