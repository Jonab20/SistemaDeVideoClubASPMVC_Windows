using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClub.Entidades.ViewModels.Calificacion
{
    public class CalificacionListViewModel
    {
        public int CalificacionId { get; set; }

        [Display(Name = @"Calificacion")]

        public string Descripcion { get; set; }
    }
}
