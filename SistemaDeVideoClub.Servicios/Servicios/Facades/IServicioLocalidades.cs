using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServicioLocalidades
    {
        List<LocalidadListDto> GetLista();
        bool Existe(LocalidadEditDto localidadEditDto);
        void Guardar(LocalidadEditDto localidadEditDto);

        void Borrar(int localidadEditDto);
        LocalidadEditDto GetLocalidadPorId(int? id);
    }
}
