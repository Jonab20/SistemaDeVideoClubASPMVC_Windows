﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels
{
    public class PaginadorGenerico
    {
        public int PaginaActual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
    }
}