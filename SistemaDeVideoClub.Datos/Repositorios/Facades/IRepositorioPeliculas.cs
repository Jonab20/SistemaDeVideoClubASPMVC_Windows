using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
using SistemaDeVideoClub.Entidades.Entidades;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioPeliculas
    {
        List<PeliculaListDto> GetLista(string listaDto/*string genero, string estado,string calificacion*/);

        bool Existe(Pelicula pelicula);

        void Guardar(Pelicula Pelicula);
        PeliculaEditDto GetPeliculaPorId(int? id);
        void Borrar(int PeliculavmId);
    }
}
