using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClub.Entidades.ViewModels.TipoDeDocumento
{
    public class TipoDeDocumentoListViewModel
    {
        public int TipoDeDocumentoId { get; set; }

        [Display(Name = @"Tipo de Documento")]

        public string Descripcion { get; set; }
    }
}
