using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels.Provincia
{
    public class ProvinciaListViewModel
    {
        public int ProvinciaId { get; set; }

        [Display(Name = @"Provincia")]

        public string NombreProvincia { get; set; }
    }
}