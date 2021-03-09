using SistemaDeVideoClubASPMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels.Pelicula
{
    public class PeliculasDetailsViewModel
    {
        public int PeliculaId { get; set; }

        [Display(Name = @"Pelicula")]
        public string Titulo { get; set; }

        [Display(Name = @"Genero")]
        public string Genero { get; set; }
        public List<Models.Genero> Generos { get; set; }

        [Display(Name = @"Fecha de incorporacion")]
        public DateTime FechaIncorporacion { get; set; }

        [Display(Name = @"Estado")]
        public string Estado { get; set; }
        public List<Estado> Estados { get; set; }

        [Display(Name = @"Minutos de duracion")]
        public int DuracionEnMinutos { get; set; }

        [Display(Name = @"Calificacion")]
        public string Calificacion { get; set; }
        public List<Calificacion> Calificaciones { get; set; }

        public bool Alquilado { get; set; }
        public bool Activa { get; set; }
        public string Observaciones { get; set; }
    }
}