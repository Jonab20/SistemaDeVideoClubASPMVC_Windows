using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels.Pelicula
{
    public class PeliculaListViewModel
    {
        public int PeliculaId { get; set; }

        [Display(Name = @"Titulo")]
        public string Titulo { get; set; }


        [Display(Name = @"Duracion en minutos")]
        public int Duracion { get; set; }


        [Display(Name = @"Activa")]
        public bool Activa { get; set; }


        [Display(Name = @"Alquilado")]
        public bool Alquilado { get; set; }


        [Display(Name = @"Genero")]
        public string Genero { get; set; }


        [Display(Name = @"Estado")]
        public string Estado { get; set; }


        [Display(Name = @"Calificacion")]
        public string Calificacion { get; set; }
    }
}