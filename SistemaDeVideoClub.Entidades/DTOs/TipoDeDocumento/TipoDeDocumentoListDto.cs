using System;

namespace SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento
{
    public class TipoDeDocumentoListDto:ICloneable
    {
        public int TipoDeDocumentoId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
