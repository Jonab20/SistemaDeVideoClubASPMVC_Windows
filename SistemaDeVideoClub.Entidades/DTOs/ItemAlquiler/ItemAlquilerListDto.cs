using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Entidades.DTOs.ItemAlquiler
{
    public class ItemAlquilerListDto
    {
        public int ItemAlquilerId { get; set; }
        //public string Socio { get; set; }
        public int Alquiler { get; set; }
        public string Pelicula { get; set; }
        public decimal PrecioAlquiler { get; set; }
    }
}
