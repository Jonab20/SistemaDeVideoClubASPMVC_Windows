using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Entidades.DTOs.Pelicula
{
     public class PeliculaListDto:ICloneable
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string CodigoPelicula { get; set; }

        //public int GeneroId { get; set; }
        public string Genero { get; set; }
        public DateTime FechaIncorporacion { get; set; }
        //public int EstadoId { get; set; }
        public string Estado { get; set; }
        public int DuracionEnMinutos { get; set; }
        //public int CalificacionId { get; set; }
        public string Calificacion { get; set; }
        public bool Alquilado { get; set; }
        public bool Activa { get; set; }
        public string Observaciones { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
