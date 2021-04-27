using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClub.Entidades.ViewModels.Soporte
{
    public class SoporteListViewModel
    {
        public int SoporteId { get; set; }

        [Display(Name = @"Soporte")]
        public string Descripcion { get; set; }
    }
}
