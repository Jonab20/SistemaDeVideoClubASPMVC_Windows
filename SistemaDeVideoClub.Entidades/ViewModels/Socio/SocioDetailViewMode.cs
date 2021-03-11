using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels.Socio
{
    public class SocioDetailViewMode
    {
        public int SocioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Display(Name = "Numero de Documento")]
        public string NroDocumento { get; set; }

        public string Direccion { get; set; }

        [Display(Name = "Numero de telefono")]
        public string TelefonoFijo { get; set; }

        [Display(Name = "Numero celular")]
        public string TelefonoMovil { get; set; }

        [Display(Name = "E-mail")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public string FechaDeNacimiento { get; set; }

        [Display(Name = "Tipo De Documento")]
        public string DescripcionTipoDeDocumento { get; set; }

        [Display(Name = "Localidad")]
        public string NombreLocalidad { get; set; }

        [Display(Name = "Provincia")]
        public string NombreProvincia { get; set; }

        public bool Sancionado { get; set; }

        public bool Activo { get; set; }

    }
}