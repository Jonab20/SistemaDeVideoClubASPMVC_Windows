using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels.Genero
{
    public class GeneroListViewModel
    {
        public int GeneroId { get; set; }

        [Display(Name = @"Genero")]

        public string Descripcion { get; set; }

    }
}