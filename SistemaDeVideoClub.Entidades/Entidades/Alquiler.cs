using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaDeVideoClub.Entidades.Entidades
{
    public class Alquiler
    {
        public int AlquilerId { get; set; }
        //public int PeliculaId { get; set; }
        //public Pelicula Pelicula { get; set; }
        public int SocioId { get; set; }
        public Socio Socio { get; set; }
        public DateTime FechaAlquiler { get; set; }
        //public int DiasAtrasados { get; set; }
        //public int total { get; set; }

        public List<ItemAlquiler> ItemsAlquiler { get; set; } = new List<ItemAlquiler>();

    }
}
