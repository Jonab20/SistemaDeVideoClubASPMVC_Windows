using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClub.Entidades.ViewModels.TipoDeSoporte
{
    public class TipoDeSoporteEditViewModel
    {
        public int SoporteId { get; set; }

        [Display(Name = @"Soporte")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        public string Descripcion { get; set; }
    }
}
