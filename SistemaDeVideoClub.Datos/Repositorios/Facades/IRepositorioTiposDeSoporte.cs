using SistemaDeVideoClub.Entidades.DTOs.TipoDeSoporte;
using SistemaDeVideoClub.Entidades.Entidades;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioTiposDeSoporte
    {
        List<TipoDeSoporteListDto> GetLista();
        TipoDeSoporteEditDto GetSoportePorId(int? id);

        void Guardar(TipoDeSoporte soporte);

        bool Existe(TipoDeSoporte soporte);

        void Borrar(int? id);
    }
}
