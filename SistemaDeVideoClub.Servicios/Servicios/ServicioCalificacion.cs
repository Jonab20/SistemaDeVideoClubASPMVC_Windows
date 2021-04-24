using AutoMapper;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Calificacion;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
//using SistemaDeVideoClubASPMVC.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios
{
    public class ServicioCalificacion : IServicioCalificaciones
    {
        private readonly IRepositorioCalificaciones _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioCalificacion(IUnitOfWork unitOfWork, IRepositorioCalificaciones repositorio)
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

        public bool Existe(CalificacionEditDto calificacionDto)
        {
            try
            {
                Calificacion calificacion = _mapper.Map<Calificacion>(calificacionDto);
                return _repositorio.Existe(calificacion);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CalificacionEditDto GetCalificacionPorId(int? id)
        {
            try
            {
                return _repositorio.GetCalificacionPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<CalificacionListDto> GetLista()
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

        public void Guardar(CalificacionEditDto calificacionDto)
        {
            try
            {
                Calificacion calificacion = _mapper.Map<Calificacion>(calificacionDto);
                _repositorio.Guardar(calificacion);
                _unitOfWork.Save();
                calificacionDto.CalificacionId = calificacion.CalificacionId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
