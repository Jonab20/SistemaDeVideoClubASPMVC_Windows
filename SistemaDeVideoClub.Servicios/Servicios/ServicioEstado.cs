using AutoMapper;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Estado;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios
{
    public class ServicioEstado : IServicioEstados
    {
        private readonly IRepositorioEstado _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioEstado(IUnitOfWork unitOfWork, IRepositorioEstado repositorio)
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
                throw new Exception(e.Message);
            }
        }

        public bool Existe(EstadoEditDto estadoDto)
        {
            try
            {
                Estado estado = _mapper.Map<Estado>(estadoDto);
                return _repositorio.Existe(estado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public EstadoEditDto GetEstadoPorId(int? id)
        {
            try
            {
                return _repositorio.GetEstadoPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<EstadoListDto> GetLista()
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

        public void Guardar(EstadoEditDto estadoDto)
        {
            try
            {
                Estado estado = _mapper.Map<Estado>(estadoDto);
                _repositorio.Guardar(estado);
                _unitOfWork.Save();
                estadoDto.EstadoId = estado.EstadoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
