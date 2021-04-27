using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
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
    public class RepositorioAlquiler /*: IRepositorioAlquiler*/
    {
        //private readonly SistemaDeVideoClubDbContext _DbContext;
        //private readonly IMapper _mapper;
        //public RepositorioAlquiler(SistemaDeVideoClubDbContext dbContext)
        //{
        //    _DbContext = dbContext;
        //    _mapper = Mapeador.CrearMapper();

        //}
        //public void Borrar(int alquilerVmId)
        //{
        //    try
        //    {
        //        var AlquilerInDb = _DbContext.Alquiler.SingleOrDefault(s => s.AlquilerId == alquilerVmId);
        //        if (AlquilerInDb == null)
        //        {
        //            throw new Exception("Alquiler inexistente");

        //        }
        //        _DbContext.Entry(AlquilerInDb).State = EntityState.Deleted;
        //    }
        //    catch (Exception)
        //    {

        //        throw new Exception("Error al Borrar alquiler");

        //    }

        //}

        //public AlquilerEditDto GetAlquilerPorId(int? id)
        //{
        //    try
        //    {
        //        return _mapper.Map<AlquilerEditDto>(_DbContext.Alquiler.SingleOrDefault(a => a.AlquilerId == id));

        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Error al cargar Alquiler");
        //    }
        //}

        //public List<AlquilerListDto> GetLista(string ListaDto)
        //{
        //    try
        //    {
        //        if (ListaDto == null)
        //        {
        //            var listaDto = _DbContext.Alquiler
        //                .Include(p => p.Pelicula)
        //                .Include(s => s.Socio)
        //                .Select(a => new AlquilerListDto
        //                {
        //                    AlquilerId = a.AlquilerId,
        //                    Pelicula = a.Pelicula.Titulo,
        //                    Socio = a.Socio.Nombre,
        //                    FechaAlquiler = a.FechaAlquiler
        //                }).ToList();
        //            return listaDto;

        //        }
        //        else
        //        {
        //            var listaDto = _DbContext.Alquiler
        //                .Include(p => p.Pelicula).Where(p => p.Pelicula.Titulo == ListaDto)
        //                .Include(s => s.Socio).Where(s => s.Socio.Nombre == ListaDto)
        //                .Select(a => new AlquilerListDto
        //                {
        //                    AlquilerId = a.AlquilerId,
        //                    Pelicula = a.Pelicula.Titulo,
        //                    Socio = a.Socio.Nombre,
        //                    FechaAlquiler = a.FechaAlquiler

        //                }).ToList();
        //            return listaDto;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Error al cargar Alquileres");


        //    }

        //}

        //public void Guardar(Alquiler alquiler)
        //{
        //    try
        //    {
        //        if (alquiler.AlquilerId == 0)
        //        {
        //            _DbContext.Alquiler.Add(alquiler);
        //        }
        //        else
        //        {
        //            var alquilerInDb = _DbContext.Alquiler.SingleOrDefault(a => a.AlquilerId == alquiler.AlquilerId);
        //            alquilerInDb.AlquilerId = alquiler.AlquilerId;
        //            alquilerInDb.PeliculaId = alquiler.PeliculaId;
        //            alquilerInDb.SocioId = alquiler.SocioId;
        //            alquilerInDb.FechaAlquiler = alquiler.FechaAlquiler;

        //            _DbContext.Entry(alquilerInDb).State = EntityState.Modified;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw new Exception("Error inesperado al guardar el alquiler");
        //    }

        //}
    }
}
