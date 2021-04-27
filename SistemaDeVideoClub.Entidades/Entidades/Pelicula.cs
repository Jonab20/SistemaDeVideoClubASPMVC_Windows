using System;

namespace SistemaDeVideoClub.Entidades.Entidades
{
    public class Pelicula
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        public DateTime FechaIncorporacion { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public int DuracionEnMinutos { get; set; }
        public int CalificacionId { get; set; }
        public Calificacion Calificacion { get; set; }
        public bool Alquilado { get; set; }
        public bool Activa { get; set; }
        public string Imagen { get; set; }
        public string Observaciones { get; set; }

    }
}
