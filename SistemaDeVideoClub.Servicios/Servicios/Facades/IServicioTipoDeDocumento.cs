using SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServicioTipoDeDocumento
    {
        List<TipoDeDocumentoListDto> GetLista();
        TipoDeDocumentoEditDto GetTipoPorId(int? id);

        void Guardar(TipoDeDocumentoEditDto Tipo);
        void Borrar(int? id);

        bool Existe(TipoDeDocumentoEditDto tipo);
    }
}
