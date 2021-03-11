using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeVideoClubASPMVC.ViewModels.Pelicula
{
    public class PeliculasDetailsViewModel
    {
        public int PeliculaId { get; set; }

        [Display(Name = @"Pelicula")]
        public string Titulo { get; set; }

        [Display(Name = @"Genero")]
        public string Genero { get; set; }

        [Display(Name = @"Fecha de incorporacion")]
        public DateTime FechaIncorporacion { get; set; }

        [Display(Name = @"Estado")]
        public string Estado { get; set; }

        [Display(Name = @"Minutos de duracion")]
        public int DuracionEnMinutos { get; set; }

        [Display(Name = @"Calificacion")]
        public string Calificacion { get; set; }
        //public List<Calificacion> Calificaciones { get; set; }

        public bool Alquilado { get; set; }
        public bool Activa { get; set; }
        public string Observaciones { get; set; }
    }
}