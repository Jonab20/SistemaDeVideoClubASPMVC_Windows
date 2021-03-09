using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels.Localidad
{
    public class LocalidadListViewModel
    {
        public int LocalidadId { get; set; }

        [Display(Name = @"Localidad")]

        public string NombreLocalidad { get; set; }


        [Display(Name = @"Provincia")]
        public string NombreProvincia { get; set; }
    }
}