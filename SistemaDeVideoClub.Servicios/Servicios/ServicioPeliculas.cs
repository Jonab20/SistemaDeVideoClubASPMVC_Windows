using AutoMapper;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios
{
    public class ServicioPeliculas : IServicioPelicula
    {
        private readonly IRepositorioPeliculas _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioPeliculas(IRepositorioPeliculas repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int peliculaEditDto)
        {
            try
            {
                _repositorio.Borrar(peliculaEditDto);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(PeliculaEditDto peliculaEditDto)
        {
            try
            {
                Pelicula pelicula = _mapper.Map<Pelicula>(peliculaEditDto);
                return _repositorio.Existe(pelicula);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<PeliculaListDto> GetLista(string listaDto)
        {
            try
            {
                return _repositorio.GetLista(listaDto);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public PeliculaEditDto GetPeliculaPorId(int? id)//TODO : CAMBIAR NOMBRE DEL METODO
        {
            try
            {
                return _repositorio.GetPeliculaPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        public void Guardar(PeliculaEditDto peliculaEditDto)
        {
            try
            {
                Pelicula pelicula = _mapper.Map<Pelicula>(peliculaEditDto);
                _repositorio.Guardar(pelicula);
                _unitOfWork.Save();
                peliculaEditDto.PeliculaId = pelicula.PeliculaId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }
    }
}
