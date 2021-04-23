using SistemaDeVideoClub.Entidades.DTOs.Estado;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServicioEstados
    {
        List<EstadoListDto> GetLista();
        EstadoEditDto GetEstadoPorId(int? id);

        void Guardar(EstadoEditDto estado);
        void Borrar(int? id);

        bool Existe(EstadoEditDto estado);
    }
}
