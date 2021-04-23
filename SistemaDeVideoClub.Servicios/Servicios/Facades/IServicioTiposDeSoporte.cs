using SistemaDeVideoClub.Entidades.DTOs.TipoDeSoporte;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServicioTiposDeSoporte
    {
        List<TipoDeSoporteListDto> GetLista();
        TipoDeSoporteEditDto GetSoportePorId(int? id);

        void Guardar(TipoDeSoporteEditDto soporte);
        void Borrar(int? id);

        bool Existe(TipoDeSoporteEditDto soporte);
    }
}
