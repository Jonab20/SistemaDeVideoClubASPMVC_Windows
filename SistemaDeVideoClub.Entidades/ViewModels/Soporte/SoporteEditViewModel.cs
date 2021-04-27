using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClub.Entidades.ViewModels.Soporte
{
    public class SoporteEditViewModel
    {
        public int SoporteId { get; set; }

        [Display(Name = @"Soporte")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        public string Descripcion { get; set; }
    }
}
