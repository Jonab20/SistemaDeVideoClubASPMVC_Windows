using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Entidades.DTOs.Alquiler
{
    public class AlquilerEditDto
    {
        public int AlquilerId { get; set; }
        public int PeliculaId { get; set; }
        public int SocioId { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public int DiasAtrasados { get; set; }
        public int total { get; set; }

    }
}
