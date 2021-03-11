using AutoMapper;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;

namespace SistemaDeVideoClub.Servicios.Servicios
{
    public class ServicioProvincia:IServiciosProvincia
    {
        private readonly IRepositorioProvincia _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWorks;

        public ServicioProvincia(IRepositorioProvincia repositorio ,IUnitOfWork unitOfWorks)
        {
            _repositorio = repositorio;
            _unitOfWorks = unitOfWorks;
            _mapper = Mapeador.CrearMapper();
        }

        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWorks.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ProvinciaEditDto provinciaDto)
        {
            try
            {
                Provincia provincia = _mapper.Map<Provincia>(provinciaDto);
                return _repositorio.Existe(provincia);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ProvinciaListDto> GetLista()
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

        public ProvinciaEditDto GetProvinciaPorId(int? id)
        {
            try
            {
                return _repositorio.GetProvinciaPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(ProvinciaEditDto provinciaDto)
        {
            try
            {
                Provincia provincia = _mapper.Map<Provincia>(provinciaDto);
                _repositorio.Guardar(provincia);
                _unitOfWorks.Save();
                provinciaDto.ProvinciaId = provincia.ProvinciaId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
