using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.Alquiler;
using SistemaDeVideoClub.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioAlquileres
    {
        void Guardar(Alquiler alquiler);
        AlquilerListDto GetAlquilerPorId(int ventaId);
        List<AlquilerListDto> GetLista();
    }
}
