using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Estado;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaDeVideoClub.Datos.Repositorios
{
    public class RepositorioEstados/* : IRepositorioEstados*/
    {
    //    private readonly SistemaDeVideoClubDbContext _DbContext;
    //    private readonly IMapper _mapper;

    //    public RepositorioEstados(SistemaDeVideoClubDbContext dbContext)
    //    {
    //        _DbContext = dbContext;
    //        _mapper = Mapeador.CrearMapper();

    //    }
    //    public void Borrar(int? id)
    //    {
    //        try
    //        {
    //            var estadoInDb = _DbContext.Estados.SingleOrDefault(e => e.EstadoId == id);
    //            _DbContext.Entry(estadoInDb).State = EntityState.Deleted;
    //        }
    //        catch (Exception)
    //        {
    //            throw new Exception("Error al intentar borar estado");
    //        }
    //    }

    //    public bool Existe(Estado estado)
    //    {
    //        if (estado.EstadoId == 0)
    //        {
    //            return _DbContext.Estados.Any(e => e.Descripcion == estado.Descripcion);
    //        }
    //        return _DbContext.Estados.Any(e => e.Descripcion == estado.Descripcion && e.EstadoId != estado.EstadoId);
    //    }

    //    public EstadoEditDto GetEstadoPorId(int? id)
    //    {
    //        try
    //        {
    //            return _mapper.Map<EstadoEditDto>(_DbContext.Estados.SingleOrDefault(e => e.EstadoId == id));
    //        }
    //        catch (Exception)
    //        {
    //            throw new Exception("Error al intentar obtener estado");
    //        }
    //    }

    //    public List<EstadoListDto> GetLista()
    //    {
    //        try
    //        {
    //            var lista = _DbContext.Estados.ToList();
    //            return _mapper.Map<List<EstadoListDto>>(lista);
    //        }
    //        catch (Exception)
    //        {
    //            throw new Exception("Error al leer los estados");
    //        }
    //    }

    //    public void Guardar(Estado estado)
    //    {
    //        try
    //        {
    //            if (estado.EstadoId == 0)
    //            {
    //                _DbContext.Estados.Add(estado);
    //            }
    //            else
    //            {
    //                var estadoInDb = _DbContext.Estados.SingleOrDefault(e => e.EstadoId == estado.EstadoId);
    //                estadoInDb.Descripcion = estado.Descripcion;
    //                _DbContext.Entry(estadoInDb).State = EntityState.Modified;
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            throw new Exception("Error inesperado al realizar la operacion de guardar");
    //        }
    //    }
    }
}
