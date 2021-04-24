using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServicioPelicula
    {
        List<PeliculaListDto> GetLista(string listaDto);
        bool Existe(PeliculaEditDto peliculaEditDto);
        void Guardar(PeliculaEditDto peliculaEditDto);

        void Borrar(int peliculaEditDto);
        PeliculaEditDto GetLocalidadPorId(int? id);
    }
}
