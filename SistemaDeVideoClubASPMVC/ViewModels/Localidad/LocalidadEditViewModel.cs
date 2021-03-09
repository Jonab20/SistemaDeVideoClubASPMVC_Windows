using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels.Localidad
{
    public class LocalidadEditViewModel
    {
        public int LocalidadId { get; set; }

        [Display(Name = @"Localidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        //[MaxLength(100, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        public string NombreLocalidad { get; set; }

        [Display(Name = @"Provincia")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ProvinciaId { get; set; }
        public List<Models.Provincia> Provincias { get; set; }

    }
}