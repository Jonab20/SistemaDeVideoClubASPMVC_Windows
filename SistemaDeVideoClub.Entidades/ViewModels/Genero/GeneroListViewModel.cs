using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClubASPMVC.ViewModels.Genero
{
    public class GeneroListViewModel
    {
        public int GeneroId { get; set; }

        [Display(Name = @"Genero")]

        public string Descripcion { get; set; }

    }
}