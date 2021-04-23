using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClub.Entidades.ViewModels.TipoDeSoporte
{
    public class TipoDeSoporteListViewModel
    {
        public int SoporteId { get; set; }

        [Display(Name = @"Soporte")]
        public string Descripcion { get; set; }
    }
}
