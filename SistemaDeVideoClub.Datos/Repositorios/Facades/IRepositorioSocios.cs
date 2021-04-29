using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using SistemaDeVideoClub.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioSocios
    {
        List<SocioListDto> GetLista(string listaDto/*string genero, string estado,string calificacion*/);

        bool Existe(Socio socio);

        void Guardar(Socio socio);
        SocioEditDto GetSocioPorId(int? id);
        void Borrar(int SociovmId);
    }
}
