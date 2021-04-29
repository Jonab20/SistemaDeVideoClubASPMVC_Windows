using SistemaDeVideoClub.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Entidades.ViewModels.Alquiler
{
    public class AlquilerListViewModel
    {
        [Display(Name = "Alquiler. Nro.")]
        public int AlquilerId { get; set; }

        [Display(Name = "Fecha alquiler.")]
        [DataType(DataType.Date)]
        public DateTime FechaAlquiler { get; set; }

        [Display(Name = "Socio")]
        public Socio Socio { get; set; }




    }
}
