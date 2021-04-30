using SistemaDeVideoClub.Entidades.ViewModels.Calificacion;
using SistemaDeVideoClub.Entidades.ViewModels.Estado;
using SistemaDeVideoClubASPMVC.ViewModels.Genero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClub.Entidades.ViewModels.Pelicula
{
    public class PeliculaEditViewModel
    {
        public int PeliculaId { get; set; }

        [Display(Name = @"Codigo de pelicula")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(4, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]

        public string CodigoPelicula { get; set; }

        [Display(Name = @"Pelicula")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(250, ErrorMessage = "El campo {0} debe contener no más de {1} caracteres")]
        public string Titulo { get; set; }


        [Display(Name = @"Genero")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int GeneroId { get; set; }
        public List<GeneroListViewModel> Generos { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaIncorporacion { get; set; }


        [Display(Name = @"Estado")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int EstadoId { get; set; }
        public List<EstadoListViewModel> Estados { get; set; }


        [Display(Name = @"Duracion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int DuracionEnMinutos { get; set; }


        [Display(Name = @"Calificacion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CalificacionId { get; set; }
        public List<CalificacionListViewModel> Calificaciones { get; set; }

        public bool Alquilado { get; set; }

        public bool Activa { get; set; }

        public string Observaciones { get; set; }

        public string Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { get; set; }
        [Display(Name = @"Socios")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int SocioId { get; set; }
        public List<GeneroListViewModel> socios { get; set; }
    }
}