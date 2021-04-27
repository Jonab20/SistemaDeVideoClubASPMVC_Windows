using AutoMapper;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Soporte;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios
{
    public class ServicioSoporte : IServicioSoporte
    {
        private readonly IRepositorioSoporte _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioSoporte(IUnitOfWork unitOfWork, IRepositorioSoporte repositorio)
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

        public bool Existe(SoporteEditDto soporteDto)
        {
            try
            {
                Soporte soporte = _mapper.Map<Soporte>(soporteDto);
                return _repositorio.Existe(soporte);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<SoporteListDto> GetLista()
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

        public SoporteEditDto GetSoportePorId(int? id)
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

        public void Guardar(SoporteEditDto soporteDto)
        {
            try
            {
                Soporte soporte = _mapper.Map<Soporte>(soporteDto);
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
