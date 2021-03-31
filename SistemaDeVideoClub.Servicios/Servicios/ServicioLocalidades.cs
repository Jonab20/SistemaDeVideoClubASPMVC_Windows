using AutoMapper;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubASPMVC.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios
{
    public class ServicioLocalidades : IServicioLocalidades
    {
        private readonly IRepositorioLocalidad _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioLocalidades(IRepositorioLocalidad repositorio,IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
            _mapper = Mapeador.CrearMapper();
        }

        public void Borrar(LocalidadEditDto localidadEditDto)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int localidadvmId)
        {
            try
            {
                _repositorio.Borrar(localidadvmId);
                _unitOfWork.Save();
            }
            catch (Exception e )
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(LocalidadEditDto localidadEditDto)
        {
            try
            {
                Localidad localidad = _mapper.Map<Localidad>(localidadEditDto);
                return _repositorio.Existe(localidad);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<LocalidadListDto> GetLista()
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

        public LocalidadEditDto GetLocalidadPorId(int? id)
        {
            try
            {           
                return _repositorio.GetLocalidadPorId(id);              
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
                
            }
        }

        public void Guardar(LocalidadEditDto localidadEditDto)
        {
            try
            {
                Localidad localidad = _mapper.Map<Localidad>(localidadEditDto);
                _repositorio.Guardar(localidad);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }
    }
}
