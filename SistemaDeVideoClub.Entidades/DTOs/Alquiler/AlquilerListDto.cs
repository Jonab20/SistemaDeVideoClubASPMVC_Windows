using SistemaDeVideoClub.Entidades.DTOs.ItemAlquiler;
using System;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Entidades.DTOs
{
    public class AlquilerListDto
    {
        public int AlquilerId { get; set; }
        //public int PeliculaId { get; set; }
        //public Pelicula Pelicula { get; set; }
        public int SocioId { get; set; }
        //public Socio Socio { get; set; }
        public DateTime FechaAlquiler { get; set; }
        //public int DiasAtrasados { get; set; }
        //public int total { get; set; }

        public List<ItemAlquilerListDto> ItemsAlquileres { get; set; } = new List<ItemAlquilerListDto>();
    }
}
