using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClubASPMVC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioLocalidad
    {
        List<LocalidadListDto> GetLista();

        bool Existe(Localidad localidad);

        void Guardar(Localidad localidad);
        LocalidadEditDto GetLocalidadPorId(int? id);
        void Borrar(int localidadvmId);
    }   
}
