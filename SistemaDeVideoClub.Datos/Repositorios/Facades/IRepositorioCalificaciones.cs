using SistemaDeVideoClub.Entidades.DTOs.Calificacion;
using SistemaDeVideoClub.Entidades.Entidades;
//using SistemaDeVideoClubASPMVC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioCalificaciones
    {
        List<CalificacionListDto> GetLista();
        CalificacionEditDto GetCalificacionPorId(int? id);

        void Guardar(Calificacion calificacion);

        bool Existe(Calificacion calificacion);

        void Borrar(int? id);
    }
}
