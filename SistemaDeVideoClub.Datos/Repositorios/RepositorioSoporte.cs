using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Soporte;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaDeVideoClub.Datos.Repositorios
{
    public class RepositorioSoporte : IRepositorioSoporte
    {
        private readonly SistemaDeVideoClubDbContext _DbContext;
        private readonly IMapper _mapper;

        public RepositorioSoporte(SistemaDeVideoClubDbContext context)
        {
            _DbContext = context;
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                var soporteInDb = _DbContext.Soporte.SingleOrDefault(s => s.SoporteId == id);
                _DbContext.Entry(soporteInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borar el soporte");
            }
        }

        public bool Existe(Soporte soporte)
        {
            if (soporte.SoporteId == 0)
            {
                return _DbContext.Soporte.Any(s => s.Descripcion == soporte.Descripcion);
            }
            return _DbContext.Soporte.Any(s => s.Descripcion == soporte.Descripcion && s.SoporteId !=soporte.SoporteId);

        }

        public List<SoporteListDto> GetLista()
        {
            try
            {
                var lista = _DbContext.Soporte.ToList();
                return _mapper.Map<List<SoporteListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer los soportes");
            }
        }

        public SoporteEditDto GetSoportePorId(int? id)
        {
            try
            {
                return _mapper.Map<SoporteEditDto>(_DbContext.Soporte.SingleOrDefault(s => s.SoporteId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar obtener soporte");
            }
        }

        public void Guardar(Soporte soporte)
        {
            try
            {
                if (soporte.SoporteId == 0)
                {
                    _DbContext.Soporte.Add(soporte);
                }
                else
                {
                    var soporteInDb = _DbContext.Soporte.SingleOrDefault(s => s.SoporteId == soporte.SoporteId);
                    soporteInDb.Descripcion = soporte.Descripcion;
                    _DbContext.Entry(soporteInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error inesperado al realizar la operacion de guardar");
            }
        }
    }
}
