using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServiciosSocios
    {
        List<SocioListDto> GetLista(string listaDto);
        bool Existe(SocioEditDto socioEditDto);
        void Guardar(SocioEditDto socioEditDto);

        void Borrar(int socioEditDto);
        SocioEditDto GetSocioPorId(int? id);
    }
}
