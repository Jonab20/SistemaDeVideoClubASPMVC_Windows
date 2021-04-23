using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClub.Entidades.ViewModels.Estado
{
    public class EstadoListViewModel
    {
        public int EstadoId { get; set; }

        [Display(Name = @"Estado")]

        public string Descripcion { get; set; }
    }
}
