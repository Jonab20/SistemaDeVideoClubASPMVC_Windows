using SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento;
using SistemaDeVideoClub.Entidades.Entidades;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioTiposDeDocumentos
    {
        List<TipoDeDocumentoListDto> GetLista();
        TipoDeDocumentoEditDto GetTipoPorId(int? id);

        void Guardar(TipoDeDocumento tipo);

        bool Existe(TipoDeDocumento tipo);

        void Borrar(int? id);

    }
}
