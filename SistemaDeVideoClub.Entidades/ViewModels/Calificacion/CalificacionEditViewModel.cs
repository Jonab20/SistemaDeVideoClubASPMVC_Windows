using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClub.Entidades.ViewModels.Calificacion
{
    public class CalificacionEditViewModel
    {
        public int CalificacionId { get; set; }

        [Display(Name = @"Calificacion")]
        [Required(ErrorMessage = "Campo Requerido")]
        [MinLength(2, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        [StringLength(30, ErrorMessage = "Campo debe contener ente {0} y {1} caracteres", MinimumLength = 4)]

        public string Descripcion { get; set; }
    }
}
