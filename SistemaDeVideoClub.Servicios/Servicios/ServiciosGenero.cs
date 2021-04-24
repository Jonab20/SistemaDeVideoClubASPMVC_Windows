using SistemaDeVideoClub.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using AutoMapper;
using SistemaDeVideoClubMVC.Mapeador;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Entidades.Entidades;
//using SistemaDeVideoClubASPMVC.Entidades;

namespace SistemaDeVideoClub.Servicios.Servicios
{
    public class ServiciosGenero : IServiciosGenero
    {
        private readonly IRepositorioGeneros _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ServiciosGenero(IRepositorioGeneros repositorio,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repositorio = repositorio;
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception (e.Message);
            }
        }

        public bool Existe(GeneroEditDto generoDto)
        {
            try
            {
                Genero genero = _mapper.Map<Genero>(generoDto);
                return _repositorio.Existe(genero);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public GeneroEditDto GetGeneroPorId(int? id)
        {
            try
            {
                return _repositorio.GetGeneroPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<GeneroListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(GeneroEditDto generoDto)
        {
            try
            {
                Genero genero = _mapper.Map<Genero>(generoDto);
                _repositorio.Guardar(genero);
                _unitOfWork.Save();
                generoDto.GeneroId = genero.GeneroId;
            }
            catch (Exception e)
            {
                throw new Exception (e.Message);
            }
        }
    }
}
