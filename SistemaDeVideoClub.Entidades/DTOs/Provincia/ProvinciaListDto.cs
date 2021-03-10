using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Entidades.DTOs.Provincia
{
    public class ProvinciaListDto:ICloneable
    {
        public int ProvinciaId { get; set; }
        public string NombreProvincia { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
