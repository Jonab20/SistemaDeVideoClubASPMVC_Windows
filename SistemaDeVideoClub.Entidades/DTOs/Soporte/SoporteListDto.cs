using System;

namespace SistemaDeVideoClub.Entidades.DTOs.Soporte
{
    public class SoporteListDto:ICloneable
    {
        public int SoporteId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
