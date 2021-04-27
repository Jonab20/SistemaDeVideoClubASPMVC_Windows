using System;

namespace SistemaDeVideoClub.Entidades.DTOs.Calificacion
{
    public class CalificacionListDto:ICloneable
    {
        public int CalificacionId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
