using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClubASPMVC.Entidades;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioGeneros
    {
        List<GeneroListDto> GetLista();
        GeneroEditDto GetGeneroPorId(int? id);

        void Guardar(Genero genero);

        bool Existe(Genero genero);

        void Borrar(int? id);
    }
}
