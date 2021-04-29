using AutoMapper;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.Alquiler;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Servicios.Servicios
{
    public class ServicioAlquiler : IServicioAlquiler
    {
        private readonly SistemaDeVideoClubDbContext _context;
        private readonly IRepositorioAlquileres _repositorio;
        private readonly IRepositorioItemAlquiler _repositorioItems;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicioAlquiler(SistemaDeVideoClubDbContext context,IRepositorioAlquileres repositorio, IRepositorioItemAlquiler repositorioItems, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _repositorioItems = repositorioItems;
            _unitOfWork = unitOfWork;
            _mapper = Mapeador.CrearMapper();
            _context = context;
        }
        public AlquilerListDto GetAlquilerPorId(int id)
        {
            try
            {
                var alquiler = _repositorio.GetAlquilerPorId(id);
                alquiler.ItemsAlquileres = _repositorioItems.GetLista(id);
                return alquiler;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public List<AlquilerListDto> GetLista()
        {
            try
            {
                var alquileres = _repositorio.GetLista();
                return alquileres;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(AlquilerEditDto alquilerEditDto)
        {
            Alquiler alquiler = _mapper.Map<Alquiler>(alquilerEditDto);
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var alquiler1 = new Alquiler()
                    {
                        AlquilerId = alquiler.AlquilerId,
                        SocioId = alquiler.SocioId,
                        FechaAlquiler = alquiler.FechaAlquiler,

                    };
                    _repositorio.Guardar(alquiler1);
                    _unitOfWork.Save();
                    foreach (var item in alquiler.ItemsAlquiler)
                    {
                        var item1 = new ItemAlquiler()
                        {
                            ItemAlquilerId = item.ItemAlquilerId,
                            AlquilerId = alquiler1.AlquilerId,
                            PeliculaId = item.Pelicula.PeliculaId,
                            PrecioAlquiler = item.PrecioAlquiler
 
                        };
                        _repositorioItems.Guardar(item1);
                    }
                    _unitOfWork.Save();
                    tran.Commit();
                    alquilerEditDto.AlquilerId = alquiler1.AlquilerId;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new Exception(e.Message);

                }
            }
        }
    }
}
