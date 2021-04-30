using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Entidades.ViewModels.Pelicula;
using SistemaDeVideoClub.Entidades.ViewModels.Socio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Entidades.ViewModels.Carrito
{
    public class ItemCarritoListViewModel
    {
        public PeliculaListViewModel PeliculaListViewModel { get; set; }
        public SocioListViewModel Socio { get; set; }
        public decimal PrecioAlquiler { get; set; }

    }
}
