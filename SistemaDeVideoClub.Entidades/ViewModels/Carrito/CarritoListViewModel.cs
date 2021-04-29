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
        public decimal PrecioAlquiler { get; set; }
        public string ReturnUrl { get; set; }
    }
}
