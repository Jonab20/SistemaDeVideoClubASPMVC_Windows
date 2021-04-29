using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Entidades.Entidades
{
    public class ItemCarrito
    {
        public Pelicula pelicula { get; set; }
        public decimal PrecioAlquiler { get; set; }

        public Socio Socio { get; set; }
        //public int Cantidad { get; set; }
        //public DateTime FechaAlquiler { get; set; }
        //public DateTime FechaDevolucion { get; set; }
    }
}
