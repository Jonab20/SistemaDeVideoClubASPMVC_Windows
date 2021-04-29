using SistemaDeVideoClub.Entidades.DTOs;
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
        List<AlquilerListDto> GetLista();
        //bool Existe(PeliculaEditDto peliculaEditDto);
        void Guardar(AlquilerEditDto alquilerEditDto);

        AlquilerListDto GetAlquilerPorId(int id);

    }
}
