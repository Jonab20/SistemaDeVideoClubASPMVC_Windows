using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Entidades.Entidades
{
    public class ItemAlquiler
    {
        public int ItemAlquilerId { get; set; }
        public int AlquilerId { get; set; }
        public int PeliculaId { get; set; }

        //public Socio Socio { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public Alquiler Alquiler { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}
