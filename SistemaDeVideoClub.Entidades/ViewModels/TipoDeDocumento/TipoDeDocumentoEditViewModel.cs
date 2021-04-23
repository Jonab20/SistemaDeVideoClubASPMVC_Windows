using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClub.Entidades.ViewModels.TipoDeDocumento
{
    public class TipoDeDocumentoEditViewModel
    {
        public int TipoDeDocumentoId { get; set; }

        [Display(Name = @"Tipo De Documento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        public string Descripcion { get; set; }

    }
}
