using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.ItemAlquiler;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos.Repositorios
{
    public class RepositorioItemAlquileres : IRepositorioItemAlquiler
    {
        private readonly SistemaDeVideoClubDbContext _context;
        private readonly IMapper _mapper;


        public RepositorioItemAlquileres(SistemaDeVideoClubDbContext context)
        {
            _context = context;
            _mapper = Mapeador.CrearMapper();
        }

        public List<ItemAlquilerListDto> GetLista(int AlquilerId)
        {
            try
            {
                var lista = _context.ItemAlquiler.Include(ia => ia.Pelicula).Where(ia => ia.AlquilerId == AlquilerId).ToList();
                return _mapper.Map<List<ItemAlquilerListDto>>(lista);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Guardar(ItemAlquiler itemAlquiler)
        {
            if (itemAlquiler.ItemAlquilerId == 0)
            {
                _context.ItemAlquiler.Add(itemAlquiler);
            }
            else
            {
                var itemInDb = _context.ItemAlquiler.SingleOrDefault(ia => ia.ItemAlquilerId == itemAlquiler.ItemAlquilerId);
                itemInDb.AlquilerId = itemAlquiler.AlquilerId;
                itemInDb.PeliculaId = itemAlquiler.PeliculaId;
                itemInDb.PrecioAlquiler = itemAlquiler.PrecioAlquiler;

                _context.Entry(itemInDb).State = EntityState.Modified;


            }
        }
    }
}
