using System;

namespace SistemaDeVideoClub.Entidades.DTOs.TipoDeSoporte
{
    public class TipoDeSoporteListDto:ICloneable
    {
        public int SoporteId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
