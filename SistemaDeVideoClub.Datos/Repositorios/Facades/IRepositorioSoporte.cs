using SistemaDeVideoClub.Entidades.DTOs.Soporte;
using SistemaDeVideoClub.Entidades.Entidades;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioSoporte
    {
        List<SoporteListDto> GetLista();
        SoporteEditDto GetSoportePorId(int? id);

        void Guardar(Soporte soporte);

        bool Existe(Soporte soporte);

        void Borrar(int? id);
    }
}
