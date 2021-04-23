using SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento;
using SistemaDeVideoClub.Entidades.Entidades;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeDocumento
    {
        List<TipoDeDocumentoListDto> GetLista();
        TipoDeDocumentoEditDto GetTipoPorId(int? id);

        void Guardar(TiposDeDocumentos tipo);

        bool Existe(TiposDeDocumentos tipo);

        void Borrar(int? id);

    }
}
