using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels.Localidad
{
    public class LocalidadDetailViewModel
    {
        public int LocalidadId { get; set; }

        [Display(Name = @"Localidad")]

        public string NombreLocalidad { get; set; }


        [Display(Name = @"Provincia")]
        public string NombreProvincia { get; set; }
        public List<Models.Provincia> Provincias { get; set; }
    }
}