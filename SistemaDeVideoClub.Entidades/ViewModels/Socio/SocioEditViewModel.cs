using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels.Socio
{
    public class SocioEditViewModel
    {
        public int SocioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(255, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        [Display(Name = "Nombre")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(255, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Tipo de documento")]
        [Display(Name = @"Tipo De Documento")]
        public int TipoDeDocumentoId { get; set; }
        //public List<Models.TipoDeDocumento> TipoDeDocumentos { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(255, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        [Display(Name = "Numero De Documento")]
        public string NroDocumento { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(255, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una localidad")]

        [Display(Name = @"Localidad")]
        public int LocalidadId { get; set; }
        //public List<Models.Localidad> Localidades { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una prvincia")]
        [Display(Name = @"Provincia")]
        public int ProvinciaId { get; set; }
        //public List<Models.Provincia> Provincias { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        [Display(Name = "Telefono Fijo")]
        public string TelefonoFijo { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        [Display(Name = "Telefono Celular")]
        public string TelefonoMovil { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(150, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        [Display(Name = "E-Mail")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaDeNacimiento { get; set; }

        public bool Sancionado { get; set; }

        public bool Activo { get; set; }

    }
}