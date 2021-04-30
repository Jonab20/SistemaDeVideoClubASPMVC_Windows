using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Entidades.ViewModels.Socio;
using SistemaDeVideoClubASPMVC.ViewModels.Socio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Entidades.ViewModels.Carrito
{
    public class CarritoListViewModel
    {
        public List<ItemCarritoListViewModel> items { get; set; }

        public int socioId { get; set; }
        public List<SocioListViewModel> socios { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public string ReturnUrl { get; set; }


    }
}
