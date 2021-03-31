using SistemaDeVideoClub.Entidades.DTOs.Genero;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServiciosGenero
    {
        List<GeneroListDto> GetLista();
        GeneroEditDto GetGeneroPorId(int? id);

        void Guardar(GeneroEditDto genero);
        void Borrar(int? id);

        bool Existe(GeneroEditDto genero);
    }
}
