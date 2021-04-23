using SistemaDeVideoClub.Entidades.DTOs.Estado;
using SistemaDeVideoClub.Entidades.Entidades;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioEstado
    {
        List<EstadoListDto> GetLista();
        EstadoEditDto GetEstadoPorId(int? id);

        void Guardar(Estado estado);

        bool Existe(Estado estado);

        void Borrar(int? id);
    }
}
