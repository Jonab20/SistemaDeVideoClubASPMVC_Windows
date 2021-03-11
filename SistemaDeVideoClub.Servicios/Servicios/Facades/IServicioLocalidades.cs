using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServicioLocalidades
    {
        List<LocalidadListDto> GetLista();
    }
}
