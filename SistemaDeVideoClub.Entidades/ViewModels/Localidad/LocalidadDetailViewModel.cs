using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClubASPMVC.ViewModels.Localidad
{
    public class LocalidadDetailViewModel
    {
        public int LocalidadId { get; set; }

        [Display(Name = @"Localidad")]

        public string NombreLocalidad { get; set; }


        [Display(Name = @"Provincia")]
        public string NombreProvincia { get; set; }
        //public List<Provincia> Provincias { get; set; }
    }
}