using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Entidades.Entidades;
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

        public RepositorioProvincias()
        {
            _DbContext = new SistemaDeVideoClubDbContext();
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                var provinciaInDb = _DbContext.provincias.Find(id);
                _DbContext.Entry(provinciaInDb).State = EntityState.Deleted;
                _DbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borar la provincia");
            }
        }

        public bool Existe(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {
                return _DbContext.provincias.Any(g => g.NombreProvincia == provincia.NombreProvincia);
            }
            return _DbContext.provincias.Any(p => p.NombreProvincia == provincia.NombreProvincia && p.ProvinciaId == provincia.ProvinciaId);
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
                    var provinciaInDb = _DbContext.provincias.Find(provincia.ProvinciaId);
                    provinciaInDb.NombreProvincia = provincia.NombreProvincia;
                }
                _DbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error inesperado al Guardar");
            }


        }
    }
}
