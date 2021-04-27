using SistemaDeVideoClub.Entidades.DTOs.Soporte;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServicioSoporte
    {
        List<SoporteListDto> GetLista();
        SoporteEditDto GetSoportePorId(int? id);

        void Guardar(SoporteEditDto soporte);
        void Borrar(int? id);

        bool Existe(SoporteEditDto soporte);
    }
}
