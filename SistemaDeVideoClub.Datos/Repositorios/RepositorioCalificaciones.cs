using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Calificacion;
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
    public class RepositorioCalificaciones /*: IRepositorioCalificaciones*/
    {
        //private readonly SistemaDeVideoClubDbContext _DbContext;
        //private readonly IMapper _mapper;

        //public RepositorioCalificaciones(SistemaDeVideoClubDbContext dbContext)
        //{
        //    _DbContext = dbContext;
        //    _mapper = Mapeador.CrearMapper();
        //}
        //public void Borrar(int? id)
        //{
        //    try
        //    {
        //        var calificacionInDb = _DbContext.Calificacion.SingleOrDefault(c => c.CalificacionId == id);
        //        _DbContext.Entry(calificacionInDb).State = EntityState.Deleted;
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Error al intentar borrar la calificacion");
        //    }
        //}

        //public bool Existe(Calificacion calificacion)
        //{
        //    if (calificacion.CalificacionId == 0)
        //    {
        //        return _DbContext.Calificacion.Any(c => c.Descripcion == calificacion.Descripcion);
        //    }
        //    return _DbContext.Calificacion.Any(c => c.Descripcion == calificacion.Descripcion && c.CalificacionId != calificacion.CalificacionId);

        //}

        //public CalificacionEditDto GetCalificacionPorId(int? id)
        //{
        //    try
        //    {
        //        return _mapper.Map<CalificacionEditDto>(_DbContext.Calificacion.SingleOrDefault(c => c.CalificacionId== id));
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Error al intentar obtener la calificacion");
        //    }
        //}

        //public List<CalificacionListDto> GetLista()
        //{
        //    try
        //    {
        //        var lista = _DbContext.Calificacion.ToList();
        //        return _mapper.Map<List<CalificacionListDto>>(lista);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Error al leer las calificaciones disponibles");
        //    }
        //    throw new NotImplementedException();
        //}

        //public void Guardar(Calificacion calificacion)
        //{
        //    try
        //    {
        //        if (calificacion.CalificacionId == 0)
        //        {
        //            _DbContext.Calificacion.Add(calificacion);
        //        }
        //        else
        //        {
        //            var calificacionInDb = _DbContext.Calificacion.SingleOrDefault(c => c.CalificacionId == calificacion.CalificacionId);
        //            calificacionInDb.Descripcion = calificacion.Descripcion;
        //            _DbContext.Entry(calificacionInDb).State = EntityState.Modified;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Error inesperado al realizar la operacion de guardar");
        //    }

        //}
    }
}
