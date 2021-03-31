using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClubASPMVC.ViewModels.Genero
{
    public class GeneroEditViewModel
    {
        public int GeneroId { get; set; }

        [Display(Name = @"Genero")]
        [Required(ErrorMessage = "Campo Requerido")]
        [MinLength(4, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        [StringLength(30, ErrorMessage = "Campo debe contener ente {0} y {1} caracteres", MinimumLength = 4)]
       
        public string Descripcion { get; set; }

    }
}