using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.TipoDeSoporte;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaDeVideoClub.Datos.Repositorios
{
    public class RepositorioTiposDeSoporte /*: IRepositorioTiposDeSoporte*/
    {
    //    private readonly SistemaDeVideoClubDbContext _DbContext;
    //    private readonly IMapper _mapper;

    //    public RepositorioTiposDeSoporte(SistemaDeVideoClubDbContext context)
    //    {
    //        _DbContext = context;
    //        _mapper = Mapeador.CrearMapper();
    //    }
    //    public void Borrar(int? id)
    //    {
    //        try
    //        {
    //            var soporteInDb = _DbContext.TipoDeSoporte.SingleOrDefault(s => s.SoporteId == id);
    //            _DbContext.Entry(soporteInDb).State = EntityState.Deleted;
    //        }
    //        catch (Exception)
    //        {
    //            throw new Exception("Error al intentar borar el soporte");
    //        }
    //    }

    //    public bool Existe(TipoDeSoporte soporte)
    //    {
    //        if (soporte.SoporteId == 0)
    //        {
    //            return _DbContext.TipoDeSoporte.Any(s => s.Descripcion == soporte.Descripcion);
    //        }
    //        return _DbContext.TipoDeSoporte.Any(s => s.Descripcion == soporte.Descripcion && s.SoporteId != soporte.SoporteId);

    //    }

    //    public List<TipoDeSoporteListDto> GetLista()
    //    {
    //        try
    //        {
    //            var lista = _DbContext.TipoDeSoporte.ToList();
    //            return _mapper.Map<List<TipoDeSoporteListDto>>(lista);
    //        }
    //        catch (Exception)
    //        {
    //            throw new Exception("Error al leer los soportes");
    //        }
    //    }

    //    public TipoDeSoporteEditDto GetSoportePorId(int? id)
    //    {
    //        try
    //        {
    //            return _mapper.Map<TipoDeSoporteEditDto>(_DbContext.TipoDeSoporte.SingleOrDefault(s => s.SoporteId == id));
    //        }
    //        catch (Exception)
    //        {
    //            throw new Exception("Error al intentar obtener soporte");
    //        }
    //    }

    //    public void Guardar(TipoDeSoporte soporte)
    //    {
    //        try
    //        {
    //            if (soporte.SoporteId == 0)
    //            {
    //                _DbContext.TipoDeSoporte.Add(soporte);
    //            }
    //            else
    //            {
    //                var soporteInDb = _DbContext.TipoDeSoporte.SingleOrDefault(s => s.SoporteId == soporte.SoporteId);
    //                soporteInDb.Descripcion = soporte.Descripcion;
    //                _DbContext.Entry(soporteInDb).State = EntityState.Modified;
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            throw new Exception("Error inesperado al realizar la operacion de guardar");
    //        }
    //    }
    }
}
