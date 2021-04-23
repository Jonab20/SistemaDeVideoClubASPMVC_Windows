using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClub.Entidades.ViewModels.Estado
{
    public class EstadoEditViewModel
    {
        public int EstadoId { get; set; }

        [Display(Name = @"Estado")]
        [Required(ErrorMessage = "Campo Requerido")]
        [MinLength(4, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        [StringLength(30, ErrorMessage = "Campo debe contener ente {0} y {1} caracteres", MinimumLength = 4)]

        public string Descripcion { get; set; }
    }
}
