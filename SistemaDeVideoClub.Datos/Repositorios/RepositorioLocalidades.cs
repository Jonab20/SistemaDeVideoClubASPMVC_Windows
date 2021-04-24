using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaDeVideoClub.Datos.Repositorios
{
    public class RepositorioLocalidades : IRepositorioLocalidades
    {
        private readonly SistemaDeVideoClubDbContext _DbContext;
        private readonly IMapper _mapper;

        public RepositorioLocalidades(SistemaDeVideoClubDbContext dbContext)
        {
            _DbContext = dbContext;
            _mapper = Mapeador.CrearMapper();
        }

        public void Borrar(int localidadvmId)
        {
            try
            {
                var localidadInDb = _DbContext.Localidades.SingleOrDefault(l => l.LocalidadId == localidadvmId);
                if (localidadInDb == null)
                {
                    throw new Exception("Localidad inexistente");

                }
                _DbContext.Entry(localidadInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al Borrar localidad");

            }
        }

        public bool Existe(Localidad localidad)
        {
            try
            {
                if (localidad.LocalidadId == 0)
                {
                    return _DbContext.Localidades.Any(l => l.NombreLocalidad == localidad.NombreLocalidad);
                }
                return _DbContext.Localidades.Any(l => l.NombreLocalidad == localidad.NombreLocalidad && l.LocalidadId != localidad.LocalidadId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LocalidadListDto> GetLista(string provincia)
        {
            try
            {
                if (provincia == null)
                {
                    var listaDto = _DbContext.Localidades.Include(l => l.Provincia).Select(p => new LocalidadListDto
                    {
                        LocalidadId = p.LocalidadId,
                        NombreLocalidad = p.NombreLocalidad,
                        Provincia = p.Provincia.NombreProvincia
                    }).ToList();
                    return listaDto;

                }
                else
                {
                    var listaDto = _DbContext.Localidades.Include(l => l.Provincia).Where(p=>p.Provincia.NombreProvincia==provincia).Select(p => new LocalidadListDto
                    {
                        LocalidadId = p.LocalidadId,
                        NombreLocalidad = p.NombreLocalidad,
                        Provincia = p.Provincia.NombreProvincia
                    }).ToList();
                    return listaDto;
                }

            }
            catch (Exception)
            {
                throw new Exception("Error al cargar localidades");
            }
        }

        public LocalidadEditDto GetLocalidadPorId(int? id)
        {
            try
            {
                return _mapper.Map<LocalidadEditDto>(_DbContext.Localidades.SingleOrDefault(l => l.LocalidadId == id));

            }
            catch (Exception)
            {
                throw new Exception("Error al cargar localidades");
            }
        }

        public void Guardar(Localidad localidad)
        {
            try
            {
                if (localidad.LocalidadId == 0)
                {
                    _DbContext.Localidades.Add(localidad);
                }
                else
                {
                    var localidadInDb = _DbContext.Localidades.SingleOrDefault(l => l.LocalidadId == localidad.LocalidadId);
                    localidadInDb.ProvinciaId = localidad.ProvinciaId;
                    localidadInDb.NombreLocalidad = localidad.NombreLocalidad;
                    _DbContext.Entry(localidadInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error inesperado al guardar la localidad");
            }
        }
    }
}
