using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels.Provincia
{
    public class ProvinciaEditViewModel
    {
        public int ProvinciaId { get; set; }

        [Display(Name = @"Provincia")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        public string NombreProvincia { get; set; }


    }
}