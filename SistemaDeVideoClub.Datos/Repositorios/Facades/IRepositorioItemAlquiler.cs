using SistemaDeVideoClub.Entidades.DTOs.ItemAlquiler;
using SistemaDeVideoClub.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public interface IRepositorioItemAlquiler
    {
        void Guardar(ItemAlquiler itemAlquiler);
        List<ItemAlquilerListDto> GetLista(int ventaId);
    }
}
