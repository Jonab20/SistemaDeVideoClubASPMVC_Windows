using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios.Facades
{
    public interface IServiciosProvincia
    {
        List<ProvinciaListDto> GetLista();
        ProvinciaEditDto GetProvinciaPorId(int? id);

        void Guardar(ProvinciaEditDto provincia);
        void Borrar(int? id);

        bool Existe(ProvinciaEditDto provincia);
    }
}
