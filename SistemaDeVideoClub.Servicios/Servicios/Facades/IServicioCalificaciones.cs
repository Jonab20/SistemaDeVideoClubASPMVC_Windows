using SistemaDeVideoClub.Entidades.DTOs.Calificacion;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServicioCalificaciones
    {
        List<CalificacionListDto> GetLista();
        CalificacionEditDto GetCalificacionPorId(int? id);

        void Guardar(CalificacionEditDto calificacion);
        void Borrar(int? id);

        bool Existe(CalificacionEditDto calificacion);

    }
}
