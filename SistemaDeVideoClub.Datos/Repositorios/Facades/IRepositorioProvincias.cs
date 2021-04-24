using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Entidades.Entidades;
//using SistemaDeVideoClubASPMVC.Entidades;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioProvincias
    {
        List<ProvinciaListDto> GetLista();
        ProvinciaEditDto GetProvinciaPorId(int? id);

        void Guardar(Provincia provincia);

        bool Existe(Provincia provincia);

        void Borrar(int? id);
        bool VerificarRelacion(Provincia provincia);
    }
}
