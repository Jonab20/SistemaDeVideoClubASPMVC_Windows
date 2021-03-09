using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.ViewModels
{
    public class Listador<T> : PaginadorGenerico where T : class
    {
        public IEnumerable<T> Registros { get; set; }
    }
}