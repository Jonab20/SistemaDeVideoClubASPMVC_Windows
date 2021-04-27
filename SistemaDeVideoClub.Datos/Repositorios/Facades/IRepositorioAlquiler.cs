using SistemaDeVideoClub.Entidades.DTOs.Alquiler;
using SistemaDeVideoClub.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioAlquiler
    {
        List<AlquilerListDto> GetLista(string listaDto);

        //bool Existe(Socio socio);

        void Guardar(Alquiler alquiler);
        AlquilerEditDto GetAlquilerPorId(int? id);
        void Borrar(int alquilerVmId);

    }
}
