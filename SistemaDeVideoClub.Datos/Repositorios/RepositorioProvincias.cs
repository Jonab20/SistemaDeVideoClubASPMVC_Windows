using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClubASPMVC.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaDeVideoClub.Datos.Repositorios
{
    public class RepositorioProvincias : IRepositorioProvincia
    {
        private readonly SistemaDeVideoClubDbContext _DbContext;
        private readonly IMapper _mapper;

        public RepositorioProvincias(SistemaDeVideoClubDbContext Dbcontext, IUnitOfWork unitOfWork)
        {
            _DbContext = Dbcontext;
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                var provinciaInDb = _DbContext.provincias.SingleOrDefault(p=>p.ProvinciaId==id);
                _DbContext.Entry(provinciaInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar la provincia");
            }
        }
        public bool Existe(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {
                return _DbContext.provincias.Any(g => g.NombreProvincia == provincia.NombreProvincia);
            }
            return _DbContext.provincias.Any(p => p.NombreProvincia == provincia.NombreProvincia && p.ProvinciaId != provincia.ProvinciaId);
        }
        public List<ProvinciaListDto> GetLista()
        {
            try
            {
                var lista = _DbContext.provincias.ToList();
                return _mapper.Map<List<ProvinciaListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer las provincias");
            }
        }
        public ProvinciaEditDto GetProvinciaPorId(int? id)
        {
            try
            {
                return _mapper.Map<ProvinciaEditDto>(_DbContext.provincias.SingleOrDefault(p => p.ProvinciaId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar obtener provincia");
            }
        }
        public void Guardar(Provincia provincia)
        {
            try
            {
                if (provincia.ProvinciaId == 0)
                {
                    _DbContext.provincias.Add(provincia);
                }
                else
                {
                    var provinciaInDb = _DbContext.provincias.SingleOrDefault(p => p.ProvinciaId == provincia.ProvinciaId);
                    provinciaInDb.NombreProvincia = provincia.NombreProvincia;
                    _DbContext.Entry(provinciaInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error inesperado al Guardar");
            }
        }

        public bool VerificarRelacion(Provincia provincia)
        {
            try
            {
                return _DbContext.localidades.Any(p => p.ProvinciaId == provincia.ProvinciaId);
            }
            catch (Exception e)
            {
                throw new Exception("Error al verificar la relacion de la provincia");
            }
        }
    }
}
