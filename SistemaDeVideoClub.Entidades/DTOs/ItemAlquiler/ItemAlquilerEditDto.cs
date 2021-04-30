using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Entidades.DTOs.ItemAlquiler
{
    public class ItemAlquilerEditDto
    {
        public int ItemAlquilerId { get; set; }
        //public int AlquilerId { get; set; }
        public PeliculaListDto Pelicula { get; set; }

        public decimal PrecioAlquiler { get; set; }
        //public SocioListDto Socio { get; set; }

        //public int AlquilerId { get; set; }
        public int SocioId { get; set; }
        //public int PeliculaId { get; set; }


    }
}
