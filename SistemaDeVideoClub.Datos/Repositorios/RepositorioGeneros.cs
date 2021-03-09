using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaDeVideoClub.Datos.Repositorios
{
    public class RepositorioGeneros : IrepositorioGeneros
    {
        private readonly SistemaDeVideoClubDbContext _DbContext;
        private readonly IMapper _mapper;
        public RepositorioGeneros()
        {
            _DbContext = new SistemaDeVideoClubDbContext();
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                var generoInDb = _DbContext.generos.Find(id);
                _DbContext.Entry(generoInDb).State = EntityState.Deleted;
                _DbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borar el genero");
            }
        }

        public bool Existe(Genero genero)
        {
            if (genero.GeneroId == 0)
            {
                return _DbContext.generos.Any(g => g.Descripcion == genero.Descripcion);
            }
            return _DbContext.generos.Any(g => g.Descripcion == genero.Descripcion && g.GeneroId == genero.GeneroId);
        }

        public GeneroEditDto GetGeneroPorId(int? id)
        {
            try
            {
                return _mapper.Map<GeneroEditDto>( _DbContext.generos.SingleOrDefault(g => g.GeneroId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar obtener genero");
            }
        }

        public List<GeneroListDto> GetLista()
        {
            try
            {
                var lista = _DbContext.generos.ToList();
                return _mapper.Map<List<GeneroListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al leer los generos");
            }
        }

        public void Guardar(Genero genero)
        {
            try
            {

                if (genero.GeneroId == 0)
                {

                    _DbContext.generos.Add(genero);

                }
                else
                {
                    var generoInDb = _DbContext.generos.Find(genero.GeneroId);
                    generoInDb.Descripcion = genero.Descripcion;
                }
                _DbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error inesperado al realizar la operacion");
            }


        }
    }
}
