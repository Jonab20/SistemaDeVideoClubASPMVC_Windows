using SistemaDeVideoClub.Entidades.DTOs.Localidad;
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
    }   
}
