using AutoMapper;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.TipoDeSoporte;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios
{
    public class ServicioTipoDeSoporte : IServicioTiposDeSoporte
    {
        private readonly IRepositorioTiposDeSoporte _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioTipoDeSoporte(IUnitOfWork unitOfWork, IRepositorioTiposDeSoporte repositorio)
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

        public bool Existe(TipoDeSoporteEditDto soporteDto)
        {
            try
            {
                TipoDeSoporte soporte = _mapper.Map<TipoDeSoporte>(soporteDto);
                return _repositorio.Existe(soporte);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoDeSoporteListDto> GetLista()
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

        public TipoDeSoporteEditDto GetSoportePorId(int? id)
        {
            try
            {
                return _repositorio.GetSoportePorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeSoporteEditDto soporteDto)
        {
            try
            {
                TipoDeSoporte soporte = _mapper.Map<TipoDeSoporte>(soporteDto);
                _repositorio.Guardar(soporte);
                _unitOfWork.Save();
                soporteDto.SoporteId = soporte.SoporteId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
