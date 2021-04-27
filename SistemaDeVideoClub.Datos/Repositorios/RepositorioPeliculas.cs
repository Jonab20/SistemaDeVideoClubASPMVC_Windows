using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos.Repositorios.Facades
{
    public class RepositorioPeliculas : IRepositorioPeliculas
    {
        private readonly SistemaDeVideoClubDbContext _DbContext;
        private readonly IMapper _mapper;
        public RepositorioPeliculas(SistemaDeVideoClubDbContext dbContext)
        {
            _DbContext = dbContext;
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int PeliculavmId)
        {
            try
            {
                var peliculaInDb = _DbContext.Pelicula.SingleOrDefault(p => p.PeliculaId == PeliculavmId);
                if (peliculaInDb == null)
                {
                    throw new Exception("Pelicula inexistente");

                }
                _DbContext.Entry(peliculaInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al Borrar pelicula");

            }
        }

        public bool Existe(Pelicula pelicula)
        {
            try
            {
                if (pelicula.PeliculaId == 0)
                {
                    return _DbContext.Pelicula.Any(p => p.Titulo == pelicula.Titulo);
                }
                return _DbContext.Pelicula.Any(p => p.Titulo == pelicula.Titulo && p.PeliculaId != pelicula.PeliculaId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PeliculaListDto> GetLista(string ListaDto/*, string estado, string calificacion*/)
        {
            try
            {
                if (ListaDto == null/*genero == null || estado == null || calificacion == null*/)
                {
                    var listaDto = _DbContext.Pelicula
                        .Include(g => g.Genero)
                        .Include(e => e.Estado)
                        .Include(c => c.Calificacion)
                        .Select(p => new PeliculaListDto
                        {
                            PeliculaId = p.PeliculaId,
                            Titulo = p.Titulo,
                            Genero = p.Genero.Descripcion,
                            FechaIncorporacion = p.FechaIncorporacion,
                            Estado = p.Estado.Descripcion,
                            DuracionEnMinutos = p.DuracionEnMinutos,
                            Calificacion = p.Calificacion.Descripcion,
                            Alquilado = p.Alquilado,
                            Activa = p.Activa,
                            Observaciones = p.Observaciones

                        }).ToList();
                    return listaDto;

                }
                else
                {
                    var listaDto = _DbContext.Pelicula
                        .Include(g => g.Genero).Where(g => g.Genero.Descripcion == ListaDto /*genero*/)
                        .Include(e => e.Estado).Where(e => e.Estado.Descripcion == ListaDto /*estado*/)
                        .Include(c => c.Calificacion).Where(c => c.Calificacion.Descripcion == ListaDto /*calificacion*/)
                        .Select(p => new PeliculaListDto
                        {
                            PeliculaId = p.PeliculaId,
                            Titulo = p.Titulo,
                            Genero = p.Genero.Descripcion,
                            FechaIncorporacion = p.FechaIncorporacion,
                            Estado = p.Estado.Descripcion,
                            DuracionEnMinutos = p.DuracionEnMinutos,
                            Calificacion = p.Calificacion.Descripcion,
                            Alquilado = p.Alquilado,
                            Activa = p.Activa,
                            Observaciones = p.Observaciones

                        }).ToList();
                    return listaDto;
                }

            }
            catch (Exception)
            {
                throw new Exception("Error al cargar peliculas");


            }
        }

        public PeliculaEditDto GetPeliculaPorId(int? id)
        {
            try
            {
                return _mapper.Map<PeliculaEditDto>(_DbContext.Pelicula.SingleOrDefault(p => p.PeliculaId == id));

            }
            catch (Exception)
            {
                throw new Exception("Error al cargar peliculas");
            }
        }

        public void Guardar(Pelicula Pelicula)
        {

            try
            {
                if (Pelicula.PeliculaId == 0)
                {
                    _DbContext.Pelicula.Add(Pelicula);
                }
                else
                {
                    var peliculaInDb = _DbContext.Pelicula.SingleOrDefault(p => p.PeliculaId == Pelicula.PeliculaId);

                    peliculaInDb.Titulo = Pelicula.Titulo;
                    peliculaInDb.GeneroId = Pelicula.GeneroId;
                    peliculaInDb.FechaIncorporacion = Pelicula.FechaIncorporacion;
                    peliculaInDb.EstadoId = Pelicula.EstadoId;
                    peliculaInDb.DuracionEnMinutos = Pelicula.DuracionEnMinutos;
                    peliculaInDb.CalificacionId = Pelicula.CalificacionId;
                    peliculaInDb.Alquilado = Pelicula.Alquilado;
                    peliculaInDb.Activa = Pelicula.Activa;
                    peliculaInDb.Observaciones = Pelicula.Observaciones;

                    _DbContext.Entry(peliculaInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error inesperado al guardar la pelicula");
            }

        }

    }
}
