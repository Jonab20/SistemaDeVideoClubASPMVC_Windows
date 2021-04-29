using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.Alquiler;
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
    public class RepositorioAlquileres: IRepositorioAlquileres
    {
        private readonly SistemaDeVideoClubDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioAlquileres(SistemaDeVideoClubDbContext context)
        {
            _context = context;
            _mapper = Mapeador.CrearMapper();
        }
        public void Guardar(Alquiler alquiler)
        {
            try
            {
                if (alquiler.AlquilerId == 0)
                {
                    _context.Alquiler.Add(alquiler);
                }
                else
                {
                    var alquilerInDb = _context.Alquiler.SingleOrDefault(a => a.AlquilerId == alquiler.AlquilerId);
                    alquilerInDb.Socio = alquiler.Socio;
                    alquilerInDb.FechaAlquiler = alquiler.FechaAlquiler;
                    //alquilerInDb.EstadoVenta = venta.EstadoVenta;
                    //ventaInDb.ModalidadVenta = venta.ModalidadVenta;
                    //ventaInDb.FechaVenta = venta.FechaVenta;
                    _context.Entry(alquilerInDb).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public AlquilerListDto GetAlquilerPorId(int AlquilerId)
        {
            try
            {
                //var venta = _context.Ventas
                //    .Include(v=>v.ItemsVentas)
                //    .SingleOrDefault(v => v.VentaId == ventaId);
                var alquiler = _context.Alquiler
                    .Select(na => new AlquilerListDto()
                    {
                        AlquilerId = na.AlquilerId,
                        SocioId = na.Socio.SocioId,
                        FechaAlquiler = na.FechaAlquiler
                        //Pelicula = na.Pelicula.Titulo,
                        //ModalidadVenta = nv.ModalidadVenta,
                        //EstadoVenta = nv.EstadoVenta
                    }).SingleOrDefault(a => a.AlquilerId == AlquilerId);

                return alquiler;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<AlquilerListDto> GetLista()
        {
            try
            {
                //var venta = _context.Ventas
                //    .Include(v=>v.ItemsVentas)
                //    .SingleOrDefault(v => v.VentaId == ventaId);
                var ventas = _context.Alquiler
                    .Select(na => new AlquilerListDto()
                    {
                        AlquilerId = na.AlquilerId,
                        SocioId = na.Socio.SocioId,
                        FechaAlquiler = na.FechaAlquiler
                        //Pelicula = na.Pelicula.Titulo,
                    }).ToList();

                return ventas;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
