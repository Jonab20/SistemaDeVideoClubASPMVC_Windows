using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServiciosGenero
    {
        List<GeneroListDto> GetLista();
        Genero GetGeneroPorId(int id);

        void Guardar(GeneroEditDto genero);
        void Borrar(int? id);

        bool Existe(GeneroEditDto genero);
    }
}
