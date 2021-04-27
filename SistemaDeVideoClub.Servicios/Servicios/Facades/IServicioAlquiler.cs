using SistemaDeVideoClub.Entidades.DTOs.Alquiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServicioAlquiler
    {
        List<AlquilerListDto> GetLista(string listaDto);
        //bool Existe(PeliculaEditDto peliculaEditDto);
        void Guardar(AlquilerEditDto alquilerEditDto);

        void Borrar(int alquilerEditDto);
        AlquilerEditDto GetAlquilerPorId(int? id);

    }
}
