using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios;
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
        private readonly RepositorioProvincias _repositorio;
        private readonly IMapper _mapper;

        public ServicioProvincia()
        {
            _repositorio = new RepositorioProvincias();
            _mapper = Mapeador.CrearMapper();
        }

        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
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
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
